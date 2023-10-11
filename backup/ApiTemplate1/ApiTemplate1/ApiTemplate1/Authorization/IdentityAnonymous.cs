using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http.Features;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
namespace ApiTemplate1.Authorization
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple =false)]
	public class IdentityAnonymous : Attribute, IAuthorizationFilter
	{
        public void OnAuthorization(AuthorizationFilterContext filterContext)
		{
			int i1 = 123;
		}
    }
}
