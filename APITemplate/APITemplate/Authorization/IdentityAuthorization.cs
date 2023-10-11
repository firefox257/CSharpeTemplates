using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ExceptionsLibrary;
using MainDBContext;
using TokenService;
using Configuration;
using GlobalTypes;

namespace APITemplate.Authorization
{

    /// <summary>
    /// The attribute class addes authorization to all end points. 
    /// This is not done directly but using this attribute directly. 
    /// Inherent from the AuthController. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IdentityAuthorization : Attribute, IAuthorizationFilter
    {
        public static  TokenService.UserDto AuthUser { get; set; }

        protected Config ? config { get; set; }
        protected ITokenService ? tokenService { get; set; }

       
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            
            bool hasAllowAnonymous = filterContext.ActionDescriptor.EndpointMetadata
                                 .Any(em => em.GetType() == typeof(IdentityAnonymous));

            if (!hasAllowAnonymous)
            {
                try
                {
                    string token = filterContext.HttpContext.Request.Headers["authToken"];

                    if (StringValues.IsNullOrEmpty(token))
                    {
                        throw new UnauthorizedException();
                    }

                    config = filterContext.HttpContext.RequestServices.GetService<Config>();

                    tokenService = filterContext.HttpContext.RequestServices.GetService<ITokenService>();
                    
                    AuthUser = tokenService.Get(token).Result;
                    if (AuthUser == null)
                    {
                        throw new UnauthorizedException();
                    }

                    AuthRoles roles = (AuthRoles)filterContext.ActionDescriptor.EndpointMetadata
                                .First(em => em.GetType() == typeof(AuthRoles));
                    bool hasRole = (from r in roles.Types where r == AuthUser.RoleId select r).Any();

                    if(!hasRole) 
                    { 
                        throw new UnauthorizedException();
                    }

                    tokenService.ResetTTL(token);

                    filterContext.HttpContext.Response.Headers.Add("authToken", token);
                    filterContext.HttpContext.Response.Headers.Add("authTokenTimeStamp", DateTime.Now.Add(config.LoginTimeout).ToString() );
                }
                catch (Exception err)
                {
                    filterContext.Result = err.GetObjectResult();
                }

            }

        }

    }
}
