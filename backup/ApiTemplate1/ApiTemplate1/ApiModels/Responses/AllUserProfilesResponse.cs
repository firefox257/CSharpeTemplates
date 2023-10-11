using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Responses
{
	public class AllUserProfilesResponse
	{
		public IEnumerable<UserProfileResponse> Users { get; set; }
	}
}
