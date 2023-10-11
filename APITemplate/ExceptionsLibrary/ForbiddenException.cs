using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLibrary
{
    public class ForbiddenException: BaseException
    {
        protected const string ErrorMessage = "Forbidden!";
        public ForbiddenException() : base(ErrorMessage)
        {
            ErrorCode = 403;
        }
        public ForbiddenException(string message = ErrorMessage) :base(message)
        {
            ErrorCode = 403;
        }
        public ForbiddenException(string message, Exception inner): base(message, inner) 
        {
            if (message == null || message == "") message = ErrorMessage;
            ErrorCode = 403;
        }
    }
}
