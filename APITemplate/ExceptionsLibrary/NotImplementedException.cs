using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLibrary
{
    public class NotImplementedException: BaseException
    {
        protected const string ErrorMessage = "Not implemented!";
        public NotImplementedException() : base(ErrorMessage)
        {
            ErrorCode = 501;
        }
        public NotImplementedException(string message = ErrorMessage) :base(message)
        {
            ErrorCode = 501;
        }
        public NotImplementedException(string message, Exception inner): base(message, inner) 
        {
            if (message == null || message == "") message = ErrorMessage;
            ErrorCode = 501;
        }
    }
}
