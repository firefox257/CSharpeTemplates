﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Requests
{
	public class AddUserProfileRequest
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
	}
}
