using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using Microsoft.OpenApi.Models;
using UserData.Extensions;
using UserService;


namespace ApiTemplate1
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var mapperConfig = new AutoMapper.MapperConfiguration(cfg =>
			{
				//Add multipule profiles.
				cfg.AddProfile(new UserService.MapperConfiguration());


			});
			services.AddSingleton(mapperConfig.CreateMapper());
			services.AddControllers();
			services.AddUserDbContext(Configuration);
			services.AddLogging(config =>
			{
				config.AddConsole()
				.AddDebug()
				.SetMinimumLevel(LogLevel.Debug)
				.AddFilter("Microsoft", LogLevel.Information);
			});





			//Add Services here
			services.AddSingleton<IUserService, UserService.UserService>();



			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "My api"
				}); ;
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(options =>
				{
					options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
				});
			}


			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
