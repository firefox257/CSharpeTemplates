using APITemplate.Controllers.UserController;
using AuthHelper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Tests.MockObjects;
using TokenService;
using UserService;
using APITemplate;
using MainDBContext;
using APITemplate.Controllers.UserController.Data;
using CachingService;
using Castle.Components.DictionaryAdapter;
using ExceptionsLibrary;

namespace ServicesTests
{
    public class UserControllerTests
    {
        
        [Fact]
        public async void TestAddUser()
        {
            var startup = new MockStartup();
            var provider = startup.Setup();

            var userService = provider.GetService<IUsersService>();
            var mapper = provider.GetService<Configuration.IMapper> ();
            var tokenService = provider.GetService<ITokenService>(); 
            var authHelper = provider.GetService<IAuthHelper>();
            var userDb = provider.GetService<IUserRepository>();
            var userController = new APITemplate.Controllers.UserController.UsersController(userService, mapper, tokenService, authHelper);
            var cacheService = provider.GetService<ICachingService>();
            var request = new AddUserApiRequest()
            {
                Email = "test1@email.com",
                First = "test1",
                Last = "user1",
                Password = "password",
                UserName = "testuser1"
            };


            var userEntity = await userDb.GetByUserName(request.UserName);
            Assert.True(userEntity == null);

            var result = await userController.Add(request);

            Assert.True(request.UserName == result.UserName);
            Assert.True(request.Email == result.Email);
            Assert.True(request.First == result.First);
            Assert.True(request.Last == result.Last);

            userEntity = await userDb.GetById(result.Id);
            Assert.True(request.UserName == userEntity.UserName);
            Assert.True(request.Email == userEntity.Email);
            Assert.True(request.First == userEntity.First);
            Assert.True(request.Last == userEntity.Last);


            var loginUser = new LoginUserApiRequest()
            {
                UserName = request.UserName,
                Password = request.Password
            };
            var loginResult = await userController.Login(loginUser);
            Assert.True(request.Email == loginResult.Email);
            Assert.True(request.First == loginResult.First);
            Assert.True(request.Last == loginResult.Last);
            Assert.True(loginResult.AuthToken != null);

            Exception? caughtError = null ;
            try
            {
                loginUser.Password = "wrong password";
                loginResult = await userController.Login(loginUser);
            }
            catch (Exception ex) 
            {
                caughtError = ex;
            }
            Assert.True(caughtError != null);
            Assert.True(caughtError.GetType() == typeof(UnauthorizedException));

        }
    }
}