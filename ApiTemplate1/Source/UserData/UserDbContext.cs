using System;

using Microsoft.EntityFrameworkCore;
using DbModels;

namespace UserData
{
	public class UserDbContext : DbContext
	{
		public DbSet<UserProfile> UserProfile { get; set; }
		public DbSet<Role> Role { get; set; }
		public UserDbContext(DbContextOptions options) : base(options)
		{ }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

		}
	}
}
