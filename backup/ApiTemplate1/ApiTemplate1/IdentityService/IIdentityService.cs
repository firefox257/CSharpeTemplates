using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApiModels.Requests;
using ApiModels.Responses;
using ApiModels;

namespace IdentityService
{
	public interface IIdentityService
	{
		Task<ResponseMessage<IdentityUserResponse> > AddUser(AddIdentityUserRequest user);
		Task<ResponseMessage<IdentityTokenResponse>> VerifyUser(VerifyUserRequest user);
		Task<ResponseMessage<IdentityTokenResponse>> RefreshToken(RefreshIdentityTokenRequest request);
	}
}
