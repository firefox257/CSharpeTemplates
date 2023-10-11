using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http.Features;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using IdentityService;
using ApiModels;
using ApiModels.Requests;
using ApiModels.Responses;
using ApiModels.Extentions;

namespace ApiTemplate1.Authorization
{
    [AttributeUsage(AttributeTargets.All)]
    public class IdentityAuthorization : Attribute, IAuthorizationFilter
    {
       
       
        public IIdentityService IdentityService { get; set; }

        public async void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            
            bool hasAllowAnonymous = filterContext.ActionDescriptor.EndpointMetadata
                                 .Any(em => em.GetType() == typeof(IdentityAnonymous));

            if (!hasAllowAnonymous)
            {
                try
                {
                    IdentityService = filterContext.HttpContext.RequestServices.GetService<IIdentityService>();
                    var token = filterContext.HttpContext.Request.Headers["authToken"];

                    if (StringValues.IsNullOrEmpty(token))
                    {
                        filterContext.Result = MakeUnauthorizedObjectResult();
                        return;
                    }

                    var refresh = await IdentityService.RefreshToken(new RefreshIdentityTokenRequest
                    {
                        Token = new Guid(token)
                    });
                    if (!refresh.Status.IsSuccess)
                    {
                        filterContext.Result = MakeUnauthorizedObjectResult();
                        return;
                    }
                    filterContext.HttpContext.Response.Headers.Add("authToken", refresh.Data.Token.ToString());
                    filterContext.HttpContext.Response.Headers.Add("authTokenTimeStamp", refresh.Data.TimeStamp.ToString());
                }
                catch(Exception ex)
				{
                    filterContext.Result = MakeUnauthorizedObjectResult();
                    return;
                }
            }

        }


        protected ObjectResult MakeUnauthorizedObjectResult()
		{
            var status = new ResponseStatus
            {
                StatusCode = ResponseStatusCode.Unauthorized,
                ExceptionErrors = new List<string>(),
                Message = "Unauthorized"

            };
            status.ExceptionErrors.Add("Unauthorized");
            var objResult = new ObjectResult(status);
            objResult.StatusCode = (int)status.StatusCode;
            return objResult;
        }

    }
}
