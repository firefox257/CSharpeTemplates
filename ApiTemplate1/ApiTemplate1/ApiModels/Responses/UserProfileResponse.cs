using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Responses
{
	public class UserProfileResponse
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public int RoleId { get; set; }
		public bool Enabled { get; set; }
	}
}
