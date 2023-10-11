using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Responses
{
	public class IdentityTokenResponse
	{
		public Guid Token { get; set; }
		public DateTime TimeStamp { get; set; }
	}
}
