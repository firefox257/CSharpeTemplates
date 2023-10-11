using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainDBContext
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) 
        { 
        }

        public async Task<UserEntity?> GetByEmail(string email)
        {
            var user = await(from u in table where u.Email == email select u).FirstOrDefaultAsync();
            return user;
        }

        public async Task<UserEntity?> GetById(int id)
        {
            var user = await (from u in table where u.Id == id select u).FirstOrDefaultAsync();
            return user;
        }

        public async Task<UserEntity?> GetByUserName(string name)
        {
            var user = await(from u in table where u.UserName == name select u).FirstOrDefaultAsync();
            return user;
        }
        
    }
}
