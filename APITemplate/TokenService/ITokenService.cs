using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TokenService
{
    public interface ITokenService
    {

        public Task<string> Create(UserDto user);
        public Task ResetTTL(string token);
        public Task<bool> Exists(string token);
        public Task<UserDto?> Get(string token);

    }
}
