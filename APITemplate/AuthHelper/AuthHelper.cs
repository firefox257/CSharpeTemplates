using Configuration;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace AuthHelper
{
    public class AuthHelper: IAuthHelper
    {
        protected Config config { get; set; }

        public AuthHelper(Config config)
        {
            this.config = config;
        }

        /// <summary>
        /// Returns the salt of a password.
        /// </summary>
        /// <param name="password">string</param>
        /// <returns>string</returns>
        public Task<string> SaltHashPass(string ? password)
        {
            if (password == null) return Task.FromResult("");
            return Task.FromResult( Convert.ToBase64String(KeyDerivation.Pbkdf2(
               password: password,
               salt: config.Salt,
               prf: KeyDerivationPrf.HMACSHA256,
               iterationCount: 100000,
               numBytesRequested: 256 / 8)));
        }

    }
}