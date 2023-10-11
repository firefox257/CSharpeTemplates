using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using EFRepository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DbModels.IdentityDbModels;
using ApiModels.Requests;
using ApiModels.Responses;
using ApiModels;
using ApiModels.Extentions;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace IdentityService
{
	public class IdentityService: IIdentityService
	{
		protected IConfiguration Configuration { get; set; }
		protected IMapper Map { get; set; }
		protected IRepository Repository { get; set; }

		protected TimeSpan TokenRefreshSeconds { get; set; }

		public IdentityService(IConfiguration configuration, IMapper map, IRepository repository)
		{
			Configuration = configuration;
			Map = map;
			Repository = repository;
			TokenRefreshSeconds = new TimeSpan(0, 0, Configuration.GetValue<int>("TokenRefreshTimeOutSeconds"));
		}
		public async Task<ResponseMessage< IdentityUserResponse> > AddUser(AddIdentityUserRequest user)
		{
			try
			{
				var userDb = new User
				{
					 Created = DateTime.Now,
					 Enabled = true,
					 PasswordHash = Hash(user.PasswordHash),
					 UserName = user.UserName
				};
				
				Repository.AddOrUpdate<User>(userDb);
				await Repository.SaveAsync();
				return new ResponseMessage<IdentityUserResponse>
				{
					Data = Map.Map<IdentityUserResponse>(userDb)
				};
			}
			catch(Exception ex)
			{
				return ex.CreateStatuses<IdentityUserResponse>();
			}
			
		}
		public async Task<ResponseMessage<IdentityTokenResponse>> VerifyUser(VerifyUserRequest user)
		{
			try
			{
				var hash = Hash(user.PasswordHash);
				var iuser = (from u in Repository.Query<User>() where u.UserName == user.UserName && u.PasswordHash == hash && u.Enabled select u).FirstOrDefault();
				if (iuser == null) throw new UnauthorizedAccessException("Unauthorized");
				

				//remove all other tokens to this user.
				var tokens = await (from t in Repository.Query<Token>() where t.UserId == iuser.Id select t).ToListAsync();
				Repository.Delete<Token>(tokens);
				await Repository.SaveAsync();
				//create  new token token
				var newToken = new Token
				{
					 Identity = Guid.NewGuid(),
					 UserId = iuser.Id,
					 TimeStamp = DateTime.Now
				};
				Repository.AddOrUpdate<Token>(newToken);
				await Repository.SaveAsync();

				return new ResponseMessage<IdentityTokenResponse>
				{
					Data = new IdentityTokenResponse
					{
						Token = newToken.Identity,
						TimeStamp = newToken.TimeStamp
					}
				};

			}
			catch(Exception ex)
			{
				return ex.CreateStatuses<IdentityTokenResponse>();
			}
		}

		public async Task<ResponseMessage<IdentityTokenResponse>> RefreshToken(RefreshIdentityTokenRequest request)
		{
			try
			{
				var itoken = (from t in Repository.Query<Token>() where t.Identity == request.Token select t).FirstOrDefault();
				if (itoken == null) throw new UnauthorizedAccessException("Unauthroized");
				var checkTimeout = DateTime.Now - itoken.TimeStamp;
				if(checkTimeout > TokenRefreshSeconds)
				{
					Repository.Delete<Token>(itoken);
					await Repository.SaveAsync();
					throw new UnauthorizedAccessException("Unauthroized");
				}
				itoken.TimeStamp = DateTime.Now;
				Repository.AddOrUpdate<Token>(itoken);
				await Repository.SaveAsync();
				return new ResponseMessage<IdentityTokenResponse>
				{
					Data = new IdentityTokenResponse
					{
						Token= itoken.Identity,
						TimeStamp = itoken.TimeStamp
					}
				};
			}
			catch(Exception ex)
			{
				return ex.CreateStatuses<IdentityTokenResponse>();
			}
		}

		protected string Hash(string pass)
		{
			using (var sha256 = SHA256.Create())
			{
				// Send a sample text to hash.  
				var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
				// Get the hashed string.  
				return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
			}
		}
	}
}
