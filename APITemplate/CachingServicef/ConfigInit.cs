using Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingService
{
    /// <summary>
    /// Add scoped services to the dependency injection.
    /// </summary>
    public static  class ConfigInit
    {
        public static void AddServices()
        {
            ConfigServices.AddScoped<ICachingService, CachingService>();
        }

    }
}
