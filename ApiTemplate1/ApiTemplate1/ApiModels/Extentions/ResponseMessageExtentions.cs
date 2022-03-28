using System;
using System.Collections.Generic;
using System.Text;
using ApiModels;
using Exceptions;
namespace ApiModels.Extentions
{
	public static class ResponseMessageExtentions
	{
		public static ResponseMessage<T> CreateStatuses<T>(this Exception ex )
		{
			var errorlist = new List<string>();

			var atException = ex;
			while (atException != null)
			{
				errorlist.Add(atException.ToString());
				atException = atException.InnerException;
			}


			ResponseStatusCode code = new ResponseStatusCode();
			if (ex is UserExistsException) code = ResponseStatusCode.UserExisits;
			else if(ex is UnauthorizedAccessException) code = ResponseStatusCode.Unauthorized;
			else code = ResponseStatusCode.Undefined;
			return new ResponseMessage<T>
			{
				Status = new ResponseStatus
				{
					StatusCode = code,
					IsSuccess = false,
					ExceptionErrors = errorlist,
					Message = ex.Message
				}
			};
		}
	}
}
