using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLibrary
{
    /// <summary>
    /// Base class exception to be used for handeling api exceptions. 
    /// </summary>
    public class BaseException: Exception
    {
        public int ErrorCode { get; set; }
        public BaseException() 
        { 
        }
        public BaseException(string message):base(message)
        {
        }
        public BaseException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    
}
