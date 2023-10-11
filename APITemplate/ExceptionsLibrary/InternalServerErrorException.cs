using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLibrary
{
    public class InternalServerErrorException: BaseException
    {
        protected const string ErrorMessage = "Internal server error!";
        public InternalServerErrorException() : base(ErrorMessage)
        {
            ErrorCode = 500;
        }
        public InternalServerErrorException(string message = ErrorMessage) :base(message)
        {
            ErrorCode = 500;
        }
        public InternalServerErrorException(string message, Exception inner): base(message, inner) 
        {
            if (message == null || message == "") message = ErrorMessage;
            ErrorCode = 500;
        }
    }
}
