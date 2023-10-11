using ExceptionsLibrary;
using MainDBContext;
using Microsoft.AspNetCore.Mvc;

namespace APITemplate
{
    public static class ExceptionExtentions
    {
        public static ObjectResult GetObjectResult(this Exception exception) 
        {
            ObjectResult result;
            var t = exception.GetType().BaseType;
            if (t == typeof(BaseException))
            {
                var ex = (BaseException)exception;
#if DEBUG
                result = new ObjectResult(new { ErrorMessage = ex.Message, StackTrace = ex.StackTrace })
                {
                    StatusCode = ex.ErrorCode
                };
#endif
#if RELEASE
                context.Result = new ObjectResult(new {ErrorMessage = ex.Message})
                {
                    StatusCode = ex.ErrorCode
                };
#endif
                return result;
            }
#if DEBUG
            result = new ObjectResult(new { ErrorMessage = exception.Message, StackTrace = exception.StackTrace })
            {
                StatusCode = 500

            };
#endif
#if RELEASE
            context.Result = new ObjectResult(new { ErrorMessage = "Internal server error! Please Contact the Administrator" })
            {
                StatusCode = 500
            };
#endif
            return result;
        }
    }
}
