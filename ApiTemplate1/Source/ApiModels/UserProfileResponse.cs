using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels
{
	public class UserProfileResponse
	{
		public int Id { get; set; }
		public string First { get; set; }
		public string Last { get; set; }
		public string Email { get; set; }
		public int RoleId { get; set; }
		public bool Enabled { get; set; }
	}
}
