using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EFRepository;


namespace UserData.Extensions
{
	public static class UserDataExtensions
	{

		public static void AddUserDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<UserDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("UserDb"));
			}, ServiceLifetime.Singleton)
			.AddTransient<DbContext, UserDbContext>()
			.AddTransient<IRepository, Repository>();
			/*services.AddDbContext<UserDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("Interview1UserDb")))
				.AddTransient<IRepository, Repository>();*/



			//services.AddTransient<DbContext, UserDbContext>();
		}
	}
}