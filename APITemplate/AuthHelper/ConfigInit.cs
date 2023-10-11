using Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHelper
{
    /// <summary>
    /// Part of the dependency injection to services localy.
    /// </summary>
    public static class ConfigInit
    {
        public static void AddServices()
        {
            ConfigServices.AddScoped<IAuthHelper, AuthHelper>();
        }
    }
}
