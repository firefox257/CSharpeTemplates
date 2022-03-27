using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Requests
{
	public class RefreshIdentityTokenRequest
	{
		public Guid Token { get; set; }
	}
}
