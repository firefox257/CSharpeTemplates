using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLibrary
{
    public class NotFoundException: BaseException
    {
        protected const string ErrorMessage = "Not found!";
        public NotFoundException() : base(ErrorMessage)
        {
            ErrorCode = 404;
        }
        public NotFoundException(string message = ErrorMessage) :base(message)
        {
            ErrorCode = 404;
        }
        public NotFoundException(string message, Exception inner): base(message, inner) 
        {
            if (message == null || message == "") message = ErrorMessage;
            ErrorCode = 404;
        }
    }
}
