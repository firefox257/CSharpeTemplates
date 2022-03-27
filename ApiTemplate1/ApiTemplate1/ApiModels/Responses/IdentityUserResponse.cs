using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace ApiModels.Responses
{
	public class IdentityUserResponse
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Updated { get; set; }
		public bool Enabled { get; set; }
	}
}
