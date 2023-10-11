using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using UserService;
using Configuration;
using APITemplate.Controllers.UserController.Data;
using TokenService;
using ExceptionsLibrary;
using AuthHelper;
using APITemplate.Authorization;

namespace APITemplate.Controllers.UserController
{
    [ApiController]
    [Route("Users")]
    public class UsersController: AuthController
    {
        protected IUsersService usersService { get; set; }
        protected IMapper mapper { get; set; }
        protected ITokenService tokenService { get; set; }
        protected IAuthHelper authHelper { get; set; }
        public UsersController(IUsersService usersService, 
            IMapper mapper, 
            ITokenService tokenService, 
            IAuthHelper authHelper)
        {
            this.usersService = usersService;
            this.mapper = mapper; 
            this.tokenService = tokenService;
            this.authHelper = authHelper;
        }

        /// <summary>
        /// Method to add users. Only Admin rights for now. 
        /// </summary>
        /// <param name="user">AddUserApiRequest</param>
        /// <returns>AddUserApiResponse</returns>
        //[AuthRoles("Admin")]
        [IdentityAnonymous]
        [HttpPost("Add")]
        public async Task<AddUserApiResponse> Add(AddUserApiRequest user)
        {
           
            var addUserDto = mapper.Map<AddUserDto>(user);
            var result = await usersService.Add(addUserDto);
            return mapper.Map<AddUserApiResponse>(result);
            
        }
        /// <summary>
        ///  Method for loging in and getting an auth token.
        /// </summary>
        /// <param name="request">LoginUserApiRequest</param>
        /// <returns>LoginUserApiResponse</returns>
        [IdentityAnonymous]
        [HttpPost("Login")]
        public async Task<LoginUserApiResponse> Login(LoginUserApiRequest request)
        {
            var tokenDto = await usersService.Login(mapper.Map<UserService.LoginDto>(request));
            return mapper.Map<LoginUserApiResponse>(tokenDto);
            
        }

    }
}
