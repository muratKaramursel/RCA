using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace RCA.Core
{
    public class DistributedCacheHelper : ICacheHelper
    {
        private readonly IDistributedCache _distributedCache;

        public DistributedCacheHelper(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public void AddToCache(string key, object value, TimeSpan? expireTimeSpan)
        {
            string valueJsonString = JsonSerializer.Serialize(value);

            _distributedCache.SetString(
                key,
                valueJsonString,
                new DistributedCacheEntryOptions()
                {
                    SlidingExpiration = expireTimeSpan
                }
            );
        }
        public void RemoveFromCache(string key)
        {
            _distributedCache.Remove(key);
        }
        public T GetFromCache<T>(string key)
        {
            string valueJsonString = _distributedCache.GetString(key);

            T value = !string.IsNullOrWhiteSpace(valueJsonString) ? JsonSerializer.Deserialize<T>(valueJsonString) : default;

            return value;
        }
    }
}