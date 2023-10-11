using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    /// <summary>
    /// Template and usage page for adding configurations for local libraries instances.
    /// </summary>
    public static class ConfigInit
    {
        static public void AddServices()
        {
            //Add services here.
            ConfigServices.AddSingleton<Config>();
        }
        static public void AddMappers()
        {
           //add mappers here
        }
        static public void AddDbContext()
        {
            //add database contexts here.
        }
    }
    
}
