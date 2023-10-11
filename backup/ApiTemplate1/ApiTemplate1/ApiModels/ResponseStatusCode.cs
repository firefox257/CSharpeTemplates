using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels
{
	public enum ResponseStatusCode
	{
		Ok = 200,
		Undefined = 500,
		UserExisits = 409,
		Unauthorized = 401

	}
}
