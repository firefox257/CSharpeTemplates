using System;
using System.Collections.Generic;
using System.Text;

namespace DbModels.UserDbModels
{
	public class UserProfile
	{
		public int Id { get; set; }
		public int IdentityId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public int RoleId { get; set; }
		public bool Enabled { get; set; }
	}
}
