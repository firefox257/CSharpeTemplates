using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CachingService
{
    public interface ICachingService
    {
        public Task AddOrUpdate<T>(string key, T value, TimeSpan timer);
        public Task ResetTTL(string key, TimeSpan timer);
        public Task<T?> Get<T>(string key);
        public Task Remove(string key);
        public Task<bool> Exists(string key);
    }
}

