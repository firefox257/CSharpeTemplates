using System;

using Microsoft.EntityFrameworkCore;
using DbModels.IdentityDbModels;

namespace IdentityData
{
	public class IdentityDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Token> Tokens { get; set; }
		public IdentityDbContext(DbContextOptions options) : base(options)
		{ }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

		}
	}
}
