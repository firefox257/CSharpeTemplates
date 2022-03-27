using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels
{
	public class AllUserProfilesResponse
	{
		IEnumerable<UserProfileResponse> Users { get; set; }
	}
}
