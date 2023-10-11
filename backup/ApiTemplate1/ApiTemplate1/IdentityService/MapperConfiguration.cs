using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DbModels.IdentityDbModels;
using ApiModels.Requests;
using ApiModels.Responses;

namespace IdentityService
{
	public class MapperConfiguration : Profile
	{
		public MapperConfiguration()
		{
			API();
		}

		protected void API()
		{
			//CreateMap<User, AddIdentityUserRequest>()
				//.ReverseMap();
			CreateMap<User, IdentityUserResponse>()
				.ReverseMap();
		}
	}
}
