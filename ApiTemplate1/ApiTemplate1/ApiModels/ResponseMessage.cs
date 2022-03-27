using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels
{
	public class ResponseMessage<T>
	{
		public T Data { get; set; }
		public ResponseStatus Status = new ResponseStatus();
	}
}
