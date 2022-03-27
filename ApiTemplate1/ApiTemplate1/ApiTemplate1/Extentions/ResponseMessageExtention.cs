using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiModels;

namespace ApiTemplate1.Extentions
{
	public static class ResponseMessageExtention
	{
		public static ObjectResult HandleResponse(this ResponseStatus status, object data = null)
		{
			if (!status.IsSuccess)
			{
				var objResult = new ObjectResult(status);
				objResult.StatusCode = (int)status.StatusCode;
				return objResult;
			}
			return new OkObjectResult(data);
		}
	}
}
