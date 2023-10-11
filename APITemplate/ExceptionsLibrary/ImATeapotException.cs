using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLibrary
{
    public class ImATeapotException: BaseException
    {
        protected const string ErrorMessage = "I'm a teapot!";
        public ImATeapotException() : base(ErrorMessage)
        {
            ErrorCode = 418;
            
        }
        public ImATeapotException(string message = ErrorMessage) :base(message)
        {
            ErrorCode = 418;
            var v1 = this.Data;
        }
        public ImATeapotException(string message, Exception inner): base(message, inner) 
        {
            if (message == null || message == "") message = ErrorMessage;
            ErrorCode = 418;
            var v1 = this.Data;
        }
    }
}
