using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels
{
	public class ResponseStatus
	{
		public ResponseStatusCode StatusCode { get; set; }
		public bool IsSuccess = true;

		public List<string> ExceptionErrors { get; set; }
		public string Message { get; set; }
	}
}
