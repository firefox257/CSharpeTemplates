using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DbModels;
using ApiModels;
namespace UserService
{
	public interface IUserService
	{
		Task<IEnumerable<AllUserProfilesResponse>> GetAllUsers();
		Task AddUser(AddUserRequest request);
	}
}
