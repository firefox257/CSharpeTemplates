using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration;
namespace TokenService
{
    /// <summary>
    /// Add scoped servces for dependency injection.
    /// </summary>
    public static class ConfigInit
    {
        public static void AddServices()
        {
            ConfigServices.AddScoped<ITokenService, TokenService>();
        }
    }
}
