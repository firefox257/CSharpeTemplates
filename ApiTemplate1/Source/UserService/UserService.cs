using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EFRepository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DbModels;
using ApiModels;

namespace UserService
{
	public class UserService : IUserService
	{
		protected IMapper Map { get; set; }
		protected IRepository Repository { get; set; }

		public UserService(IMapper map, IRepository repository)
		{
			Map = map;
			Repository = repository;
		}

		public async Task<IEnumerable<AllUserProfilesResponse>> GetAllUsers()
		{

			var users = await (from u in Repository.Query<UserProfile>() select u).ToListAsync();


			return Map.Map<List<AllUserProfilesResponse>>(users);
		}

		public async Task AddUser(AddUserRequest request)
		{
			UserProfile user = new UserProfile
			{
				IdentityId = new Guid(),
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				Enabled = true,
				RoleId = 0
			};

			Repository.AddOrUpdate<UserProfile>(user);
			await Repository.SaveAsync();

		}

	}
}
