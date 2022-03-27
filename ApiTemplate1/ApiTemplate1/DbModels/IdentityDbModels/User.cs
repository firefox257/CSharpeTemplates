using System;
using System.Collections.Generic;
using System.Text;

namespace DbModels.IdentityDbModels
{
	public class User
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public DateTime Created { get; set; }
		public DateTime ? Updated { get; set; }
		public bool Enabled { get; set; }
		public string PasswordHash { get; set; }
	}
}
