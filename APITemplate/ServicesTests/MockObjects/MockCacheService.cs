using CachingService;
using Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.MockObjects
{
    public class MockCacheService : ICachingService
    {
        public Dictionary<string, object> data = new Dictionary<string, object>();
        protected Config config { get; set; }
        public MockCacheService(Config config)
        {
            this.config = config;
        }
        public async Task AddOrUpdate<T>(string key, T value, TimeSpan timer)
        {
            data[key] = value;
        }

        public async Task<bool> Exists(string key)
        {
            return data.ContainsKey(key);
        }

        public async Task<T?> Get<T>(string key)
        {
            return (T)data[key] ?? default(T?);
        }

        public async Task Remove(string key)
        {
            data.Remove(key); ;
        }

        public async Task ResetTTL(string key, TimeSpan timer)
        {
            //do nothing.
        }
    }
}
