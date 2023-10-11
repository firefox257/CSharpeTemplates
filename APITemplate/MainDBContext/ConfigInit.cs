using Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MainDBContext
{
    public class ConfigInit
    {

        /// <summary>
        /// This class and its methods adds  context in the dependency injection pipeline.
        /// </summary>
        public static void AddDbContexts()
        {
            ConfigDBContext.AddDbContext<DbContext, Context>();
        }
        public static void AddServices()
        {
            ConfigServices.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
