using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EFRepository;


namespace ApiData.Extensions
{
	public static class ApiDataExtensions
	{

		public static void AddUserDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApiDababaseContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("ApiDb"));
			}, ServiceLifetime.Singleton)
			.AddTransient<DbContext, ApiDababaseContext>()
			.AddTransient<IRepository, Repository>();
		}
	}
}