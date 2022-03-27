using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Requests
{
	public class AddIdentityUserRequest
	{
		public string UserName { get; set; }
		public string PasswordHash { get; set; }
	}
}
