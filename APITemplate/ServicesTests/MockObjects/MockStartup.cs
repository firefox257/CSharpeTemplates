using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq.EntityFrameworkCore;
using Moq;
using MainDBContext;
using Configuration;
using AutoMapper;
using CachingService;
using Microsoft.EntityFrameworkCore;

namespace Tests.MockObjects
{
    public class MockStartup : ServiceCollection
    {
        protected List<UserEntity> ? Users { get; set; }
        protected bool DatabaseIsSetup = false;

        public MockStartup() 
        {
            Tests.AssemblyConfigurationCaller.Setup();
        }

        protected void SetupMappers()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                //Handel all added mappers in ConfigInit.cs files.
                Configuration.ConfigMappers.Setup(cfg, cfg.GetType());
            });
            var mapper = new Configuration.ConfigWrapperMapper(mapperConfig);
            this.AddSingleton<Configuration.IMapper>(mapper);

        }
        protected void SetupDatabase()
        {
            ConfigDBContext.DbContextList.Clear();
            ConfigDBContext.AddDbContext<DbContext, MockDatabaseContext>();
            ConfigDBContext.Setup(this, typeof(EntityFrameworkServiceCollectionExtensions));

        }

        protected void SetupServices()
        {
            ConfigServices.AddScoped<ICachingService, MockCacheService>();
            ConfigServices.Setup(this, typeof(ServiceCollectionServiceExtensions));
        }

        public ServiceProvider Setup()
        {
            SetupMappers();
            SetupDatabase();
            SetupServices();

            var sp = this.BuildServiceProvider();
            return sp;
        }
        


    }
}
