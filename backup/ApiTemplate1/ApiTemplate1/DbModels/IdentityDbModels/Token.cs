using System;
using System.Collections.Generic;
using System.Text;

namespace DbModels.IdentityDbModels
{
	public class Token
	{
		public int Id { get; set; }
		public Guid Identity {get; set;}
		public DateTime TimeStamp { get; set; }
		public int UserId { get; set; }
	}
}
