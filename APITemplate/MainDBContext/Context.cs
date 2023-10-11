using Microsoft.EntityFrameworkCore;
using Configuration;

namespace MainDBContext
{
    /// <summary>
    /// Database context for UserEntities
    /// </summary>
    public class Context: DbContext
    {
        protected Config config { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }

        public Context(Config config)
        {
            this.config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(config.DBConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public async Task<UserEntity> AddUser(UserEntity entity)
        {
            UserEntities.Add(entity);
            await SaveChangesAsync();
            var result = await(from ue in UserEntities where ue.UserName == entity.UserName select ue).FirstAsync();
            return result;
        }
    }
}