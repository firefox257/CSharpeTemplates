using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TokenService;
namespace APITemplate.Authorization
{
    /// <summary>
    /// The class used used as an inheritance class to automaticly add authorization to the controller end points.
    /// The auth user is the logged in user from the token id. 
    /// </summary>
    [IdentityAuthorization]
    public class AuthController : Controller
    {
        /// <summary>
        /// The propertiy gets direcxtly from IdentityAuthorization as that attribute pipeline will set the the AuthUser as they are log in.
        /// </summary>
        public static UserDto? AuthUser
        {
            get
            {

                return IdentityAuthorization.AuthUser;
            }
        }
        
           
    }
}
