using Configuration;
using ExceptionsLibrary;

namespace PingService
{
    public class PingService : IPingService
    {

        /// <summary>
        /// Return a response to see if the server is running. 
        /// </summary>
        /// <returns>PingResponse</returns>
        public Task<PingResponse> GetHello()
        {
            return Task.FromResult(new PingResponse
            {
                Hello = "Pong",
                TimeStamp = DateTime.Now
            });
        }
        /// <summary>
        /// Throws an excption for testing the exception.
        /// </summary>
        /// <exception cref="ImATeapotException"></exception>
        public Task<string> TestException()
        {
            throw new ImATeapotException();
        }
    }
}