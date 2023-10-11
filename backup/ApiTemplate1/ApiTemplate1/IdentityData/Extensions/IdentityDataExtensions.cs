using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EFRepository;


namespace IdentityData.Extensions
{
	public static class IdentityDataExtensions
	{
		public static void AddIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<IdentityDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("ApiDb"));
			}, ServiceLifetime.Singleton)
			.AddTransient<DbContext, IdentityDbContext>()
			.AddTransient<IRepository, Repository>();
			/*services.AddDbContext<UserDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("Interview1UserDb")))
				.AddTransient<IRepository, Repository>();*/



			//services.AddTransient<DbContext, UserDbContext>();
		}
	}
}
