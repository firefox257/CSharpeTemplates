namespace ExceptionsLibrary
{
    public class UnauthorizedException: BaseException
    {
        protected const string ErrorMessage = "Unauthorized!";
        public UnauthorizedException() : base(ErrorMessage)
        {
            ErrorCode = 401;
        }
        public UnauthorizedException(string message = ErrorMessage) : base(message)
        {
            ErrorCode = 401;
        }
        public UnauthorizedException(string message, Exception inner) : base(message, inner)
        {
            if (message == null || message == "") message = ErrorMessage;
            ErrorCode = 401;
        }

    }
}