using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DbModels.UserDbModels;
using ApiModels.Requests;
using ApiModels.Responses;

namespace UserService
{
	public class MapperConfiguration : Profile
	{
		public MapperConfiguration()
		{
			API();
		}

		protected void API()
		{
			CreateMap<UserProfile, UserProfileResponse>()
				.ReverseMap();
			CreateMap<Role, RoleResponse>()
				.ReverseMap();
		}
	}
}
