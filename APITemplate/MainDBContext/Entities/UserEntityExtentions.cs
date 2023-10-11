using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MainDBContext
{
    /// <summary>
    /// Add convinenat methods for reusability on database items. 
    public static class UserEntityExtentions
    {

        /*public static async Task<UserEntity> AddUser(this IDbContext db, UserEntity entity)
        {
            db.UserEntities.Add(entity);
            await db.SaveChangesAsync();
            var result = await (from ue in db.UserEntities where ue.UserName == entity.UserName select ue).FirstAsync();
            return result;
        }
        public static async Task<UserEntity?> GetUserByUserName(this Context db, string userName)
        {
            var result = await (from ue in db.UserEntities where ue.UserName == userName select ue).FirstOrDefaultAsync();
            return result;
        }
        public static async Task<UserEntity?> GetUserByEmail(this Context db, string email)
        {
            var result = await (from ue in db.UserEntities where ue.Email == email select ue).FirstOrDefaultAsync();
            return result;
        }*/
    }
}
