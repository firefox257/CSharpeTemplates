using APITemplate.Controllers.PingController.Data;
using Configuration;
using Microsoft.AspNetCore.Mvc;
using PingService;
using APITemplate.Authorization;
using TokenService;
using GlobalTypes;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace APITemplate.Controllers.PingController
{

    [ApiController]
    [Route("Ping")]
    public class PingController : AuthController
    {
        protected IPingService PingService { get; set; }
        protected Config config { get; set; }
        protected IMapper mapper { get; set; }

        public PingController(IPingService pingService, Config config, IMapper mapper)
        {
            PingService = pingService;
            this.config = config;
            this.mapper = mapper;
        }

        /// <summary>
        /// End point to see if server is alive.
        /// </summary>
        /// <returns>ApiPingResponse</returns>
        [IdentityAnonymous]
        [HttpGet("Hello")]
        public async Task<ApiPingResponse> GetHello()
        {
            var result = mapper.Map<ApiPingResponse>(await PingService.GetHello());

            return result;
        }

        /// <summary>
        /// Test how exceptoins are presented to the end point.
        /// </summary>
        /// <returns>Exception</returns>
        [IdentityAnonymous]
        [HttpGet("TestException")]
        public async Task<IActionResult> TestException()
        {
            return Ok(await PingService.TestException());
        }

        /// <summary>
        /// Test to see if authorization is working. Returns the logged in user. 
        /// </summary>
        /// <returns> UserDto</returns>
        [AuthRoles("User", "Admin")]
        [HttpGet("TestAuthorization")]
        public async Task<UserDto> TestAuthorization()
        {
            var auth = AuthUser;
            return auth;
        }

        /// <summary>
        /// Test for admin authroization, a test for a specific role.
        /// </summary>
        /// <returns>UserDto</returns>
        [AuthRoles("Admin")]
        [HttpGet("TestAdminAuthorization")]
        public async Task<UserDto> TestAdminAuthorization()
        {
            var auth = AuthUser;
            return auth;
        }

    }
}
