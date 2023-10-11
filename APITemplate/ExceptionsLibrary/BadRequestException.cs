using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExceptionsLibrary
{
    public class BadRequest: BaseException
    {
        protected const string ErrorMessage = "Bad request!";
        public BadRequest() : base(ErrorMessage)
        {
            ErrorCode = 400;
        }
        public BadRequest(string message = ErrorMessage):base(message)
        {
            ErrorCode = 400;
        }
        public BadRequest(string message, Exception inner): base(message, inner) 
        {
            if (message == null || message == "") message = ErrorMessage;
            ErrorCode = 400;
        }
    }
}
