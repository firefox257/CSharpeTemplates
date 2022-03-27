using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DbModels;
using ApiModels.Requests;
using ApiModels.Responses;
using ApiModels;

namespace UserService
{
	public interface IUserService
	{
		Task<ResponseMessage<AllUserProfilesResponse>> GetAllUsers();
		Task<ResponseMessage<UserProfileResponse>> AddUser(AddUserProfileRequest request);
	}
}
