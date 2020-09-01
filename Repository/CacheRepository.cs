using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedisWebAPIDemo.Repository
{
    public static class CacheRepository
    {
        // save 
        public static async Task SetObjectAsync<T>(IDistributedCache cache, string key, T value)
        {
            await cache.SetStringAsync(key, JsonConvert.SerializeObject(value));
        }

        // get
        public static async Task<T> GetObjectAsync<T>(IDistributedCache cache, string key)
        {
            var value = await cache.GetStringAsync(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

    }
}
