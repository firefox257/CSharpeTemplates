using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService
{
    public interface IUsersService
    {
        public Task<UserDto> Add(AddUserDto userRequest);
        public Task<TokenDto> Login(LoginDto login);

        
        
    }
}
