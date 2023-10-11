using Configuration;
using PingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingService
{
    /// <summary>
    /// Adding scoped service to the dependency injection.
    /// </summary>
    public static class ConfigInit
    {
        static public void AddServices()
        {
            ConfigServices.AddScoped<IPingService, PingService>();
        }
    }
}
