using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EFRepository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DbModels.UserDbModels;
using ApiModels.Requests;
using ApiModels.Responses;
using ApiModels.Extentions;
using ApiModels;
using IdentityService;
using Exceptions;

namespace UserService
{
	public class UserService : IUserService
	{
		protected IMapper Map { get; set; }
		protected IRepository Repository { get; set; }
		protected IIdentityService IdentityService { get; set; }
		public UserService(IMapper map, IRepository repository, IIdentityService identityService)
		{
			Map = map;
			Repository = repository;
			IdentityService = identityService;
		}

		public async Task<ResponseMessage<AllUserProfilesResponse>> GetAllUsers()
		{

			try
			{
				var users = await (from u in Repository.Query<UserProfile>() select u).ToListAsync();

				return new ResponseMessage<AllUserProfilesResponse>
				{
					Data = new AllUserProfilesResponse
					{
						Users = Map.Map<List<UserProfileResponse>>(users)
					}
				};
			}
			catch (Exception ex)
			{
				return ex.CreateStatuses<AllUserProfilesResponse>();
			}
		}

		public async Task<ResponseMessage< UserProfileResponse?>> AddUser(AddUserProfileRequest request)
		{

			try
			{

				var findUser = await (from u in Repository.Query<UserProfile>() where u.Email == request.Email select u).FirstOrDefaultAsync();

				if (findUser != null) throw new UserExistsException("User exists.");
				var iuserRequest = new AddIdentityUserRequest
				{
					UserName = request.Email,
					PasswordHash = request.PasswordHash
				};
				var iuserResponse = await IdentityService.AddUser(iuserRequest);
				

				UserProfile user = new UserProfile
				{
					IdentityId = iuserResponse.Data.Id,
					FirstName = request.FirstName,
					LastName = request.LastName,
					Email = request.Email,
					Enabled = true,
					RoleId = 0
				};

				Repository.AddOrUpdate<UserProfile>(user);


				await Repository.SaveAsync();

				var response = new ResponseMessage<UserProfileResponse?>
				{
					Data = Map.Map<UserProfileResponse>(user)
				};
				return response;
			}
			catch(Exception ex)
			{
				return ex.CreateStatuses<UserProfileResponse>();
			}

		}

	}
}
