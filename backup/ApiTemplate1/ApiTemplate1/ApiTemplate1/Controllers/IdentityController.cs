using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTemplate1.Authorization;
using AutoMapper;
using IdentityService;
using ApiModels.Requests;
using ApiModels.Responses;
using ApiTemplate1.Extentions;

namespace ApiTemplate1.Controllers
{
	[IdentityAuthorization]
	[Route("api/v1/[controller]/[action]")]
	[ApiController]
	public class IdentityController : Controller
	{
		IMapper Map { get; set; }
		IIdentityService IdentityService { get; set; }
		public IdentityController(IMapper map, IIdentityService identityService)
		{
			Map = map;
			IdentityService = identityService;
		}

		[IdentityAnonymous]
		[HttpPost, ActionName("verify")]
		public async Task<IActionResult> VerifyUser([FromBody] VerifyUserRequest request)
		{
			var response = await IdentityService.VerifyUser(request);
			return response.Status.HandleResponse(response.Data);
		}

	}
}
