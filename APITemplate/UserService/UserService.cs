
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthHelper;
using Configuration;
using MainDBContext;
using GlobalTypes;
using TokenService;
using ExceptionsLibrary;
namespace UserService
{
    public class UsersService : IUsersService
    {


        protected IUserRepository db { get; set; }
        protected IAuthHelper authHelper { get; set; }
        protected IMapper mapper { get; set; }
        protected ITokenService tokenService { get; set; }

        public UsersService(IUserRepository db, IAuthHelper authHelper, IMapper mapper, ITokenService tokenService)
        {
            this.db = db;
            this.authHelper = authHelper;
            this.mapper = mapper;
            this.tokenService = tokenService;
        }

        public async Task<UserDto> Add(AddUserDto userRequest)
        {
            var entity = mapper.Map<UserEntity>(userRequest);
            entity.Created = DateTime.Now;
            entity.LastUpdated = DateTime.Now;
            entity.RoleId = RoleType.User;
            entity.PassHash = await authHelper.SaltHashPass(userRequest.Password);
            
            await db.AddAsync(entity);
            var result = await db.GetByUserName(userRequest.UserName);
            return mapper.Map<UserDto>(result);
        }

        public async Task<TokenDto> Login(LoginDto login)
        {
            UserEntity ? user;
            if(login.UserName != null)
            {
                user = await db.GetByUserName(login.UserName);
            }
            else if(login.Email != null) 
            {
                user = await db.GetByEmail(login.Email);
            }
            else
            {
                throw new UnauthorizedException();
            }

            if (user == null)
            {
                throw new UnauthorizedException();
            }
            //Todo move portion as part of a configuration
            /*if(user.Deleted || !user.AdminVerified || user.Blocked)
            {
                throw new UnauthorizedException();
            }*/

            var saltHash = await authHelper.SaltHashPass(login.Password);
            if(user.PassHash != saltHash)
            {
                throw new UnauthorizedException();
            }
            var userDto = mapper.Map<TokenService.UserDto>(user);
            var token = await tokenService.Create(userDto);
            var tokenDto = mapper.Map<TokenDto>(user);
            tokenDto.AuthToken = token;
            return tokenDto;
        }

    }
}
