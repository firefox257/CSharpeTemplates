using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTemplate1.Authorization;
using AutoMapper;
using UserService;
using IdentityService;
using ApiModels.Requests;
using ApiModels.Responses;
using ApiTemplate1.Extentions;


namespace Interview1.Controllers
{
	[IdentityAuthorization]
	[Route("api/v1/[controller]/[action]")]
	[ApiController]
	public class UserController : Controller
	{
		protected IMapper Map { get; set; }
		protected IUserService UserService { get; set; }
		protected IIdentityService IdentityService { get; set; }
		
		public UserController(IMapper map, IUserService userService)
		{
			Map = map;
			UserService = userService;
			

		}

		[HttpGet, ActionName("all")]
		public async Task<IActionResult> GetAllUsers()
		{
			var users = await UserService.GetAllUsers();
			return users.Status.HandleResponse( users.Data);
		}

		[IdentityAnonymous]
		[HttpPost, ActionName("add")]
		public async Task<IActionResult> AddUser([FromBody] AddUserProfileRequest request)
		{
			var response = await UserService.AddUser(request);
			return response.Status.HandleResponse(response.Data);
		}
	}
}
