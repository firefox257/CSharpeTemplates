using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainDBContext
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity?> GetById(int id);
        Task<UserEntity?> GetByUserName(string name);
        Task<UserEntity?> GetByEmail(string email);
    }
}
