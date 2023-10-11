using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MainDBContext;
using Moq;
using Moq.EntityFrameworkCore;
using GlobalTypes;
using Configuration;
using Microsoft.EntityFrameworkCore;

namespace Tests.MockObjects
{
    public class MockDatabaseContext: DbContext
    {
        //This is "password"
        protected const string basePasswordHash = "BwJPWHKlO1KK0QoYh2ilVXJY3P9ZMR9AT42laKpT4Mg=";
        protected Config config { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        public MockDatabaseContext(Config config) 
        {
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("MainDB");//UseSqlServer(config.DBConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /*public void AddTestAdmin()
        {
            this.UserEntities.Add(new UserEntity()
            {
                Id = 1,
                UserName = "AdminTest",
                First = "Admin",
                Last = "Test",
                AdminVerified = true,
                PassHash = basePasswordHash,
                RoleId = RoleType.Admin,
                Created = DateTime.Now
            });
            this.SaveChanges();
            
        }
        public void AddTestUser()
        {
            this.UserEntities.Add(new UserEntity()
            {
                Id = 1,
                UserName = "UserTest1",
                First = "User1",
                Last = "Test1",
                AdminVerified = true,
                PassHash = basePasswordHash,
                RoleId = RoleType.User,
                Created = DateTime.Now
            });
            this.SaveChanges(); ;
            
        }
        public void AddSomeUsers()
        {
            AddTestAdmin();
            AddTestUser();
        }

        public void AddUser(UserEntity user)
        {
            //users.Add(user);
            this.UserEntities.Add(user);
            this.SaveChanges();
        }

        public void AddUsers(IEnumerable<UserEntity> users)
        {
            this.UserEntities.AddRange(users);
            this.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }*/
    }
}
