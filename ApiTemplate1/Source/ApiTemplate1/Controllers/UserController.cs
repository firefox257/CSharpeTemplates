using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UserService;
using ApiModels;

namespace Interview1.Controllers
{
	[Route("api/v1/[controller]/[action]")]
	[ApiController]
	public class UserController : Controller
	{
		IMapper Map { get; set; }
		IUserService UserService { get; set; }
		public UserController(IMapper map, IUserService userService)
		{
			Map = map;
			UserService = userService;

		}

		[HttpGet, ActionName("all")]
		public async Task<IActionResult> GetAllUsers()
		{
			var users = await UserService.GetAllUsers();

			return Ok(users);
		}

		[HttpPost, ActionName("add")]
		public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
		{
			await UserService.AddUser(request);
			return Ok();
		}
	}
}
