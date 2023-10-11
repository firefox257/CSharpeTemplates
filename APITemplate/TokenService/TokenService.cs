
using CachingService;
using Configuration;

namespace TokenService
{
    public class TokenService : ITokenService
    {
        protected Config config { get; set; }
        protected ICachingService cachingService;
        public TokenService(Config config, ICachingService cachingService) 
        { 
            this.config = config;
            this.cachingService = cachingService;
        }

        /// <summary>
        /// Create or updated a token for the users. 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>string</returns>
        public async Task<string> Create(UserDto user)
        {
            Guid g = Guid.NewGuid();
            string gstr = g.ToString();
            await cachingService.AddOrUpdate(gstr, user, config.LoginTimeout);
            return gstr;
        }

        /// <summary>
        /// Reset the time to live on a key value
        /// </summary>
        /// <param name="token">string</param>
        /// <returns></returns>
        public async Task ResetTTL(string token)
        {
            await cachingService.ResetTTL(token, config.LoginTimeout);
        }
        /// <summary>
        /// See if key exists in the caching service.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<bool> Exists(string token)
        {
            return await cachingService.Exists(token); 
        }
        /// <summary>
        /// Get the user from the caching servce. 
        /// </summary>
        /// <param name="token">string</param>
        /// <returns>UserDto</returns>
        public async Task<UserDto?> Get(string token)
        {
            return await cachingService.Get<UserDto>(token);
        }

    }
}