using System;

using Microsoft.EntityFrameworkCore;
using DbModels.UserDbModels;
using DbModels.IdentityDbModels;

namespace ApiData
{
	public class ApiDababaseContext : DbContext
	{
		public DbSet<UserProfile> UserProfile { get; set; }
		public DbSet<Role> Role { get; set; }

		public DbSet<User> User { get; set; }
		public DbSet<Token> Token { get; set; }

		public ApiDababaseContext(DbContextOptions options) : base(options)
		{ }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

		}
	}
}
