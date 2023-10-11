using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Configuration;

namespace MainDBContext
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext context { get; set; }
        protected DbSet<T> table { get; set; }
        public Repository(DbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await table.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            table.Remove(entity); ;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await (from d in table select d).ToListAsync();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
