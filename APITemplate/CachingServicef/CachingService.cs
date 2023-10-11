using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StackExchange.Redis;
using Configuration;
using System.Text.Encodings.Web;

namespace CachingService
{
    /// <summary>
    /// Added key values to a caching back end.
    /// </summary>
    public class CachingService: ICachingService
    {
        protected Config config { get; set; }
        protected ConnectionMultiplexer redis { get; set; }
        protected IDatabase rdb { get; set; }
        public CachingService(Config config) 
        { 
            this.config = config;
            redis = ConnectionMultiplexer.Connect(config.RedisConnectionString);
            rdb = redis.GetDatabase();
        }
        /// <summary>
        /// Update a key object to memory caching.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">string</param>
        /// <param name="value">T</param>
        /// <param name="timer">TimeSpan</param>
        /// <returns></returns>
        public async Task AddOrUpdate<T>(string key, T value, TimeSpan timer)
        {

            await rdb.StringSetAsync(key, JsonSerializer.Serialize(value), timer);
        }

        /// <summary>
        /// Rest the timer ttl on an existing key.
        /// </summary>
        /// <param name="key">string</param>
        /// <param name="timer">TimeSpan</param>
        /// <returns></returns>
        public async Task ResetTTL(string key, TimeSpan timer)
        {
            await rdb.StringGetSetExpiryAsync(key, timer);
        }
        /// <summary>
        /// Get an existing key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">string</param>
        /// <returns>T</returns>
        public async Task<T?> Get<T>(string key)
        {
            string ? s = await rdb.StringGetAsync(key);
            return JsonSerializer.Deserialize<T>(s);
        }

        /// <summary>
        /// Remove a key value.
        /// </summary>
        /// <param name="key">string</param>
        /// <returns></returns>
        public async Task Remove(string key)
        {
            await rdb.KeyDeleteAsync(key);
        }
        /// <summary>
        /// See if key exists in the cache.
        /// </summary>
        /// <param name="key">string</param>
        /// <returns>bokol</returns>
        public async Task<bool> Exists(string key)
        {
            return await rdb.KeyExistsAsync(key);
        }
    }
}
