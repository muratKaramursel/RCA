using Microsoft.Extensions.Caching.Distributed;
using System.Text;
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

            byte[] valueByteArray = Encoding.UTF8.GetBytes(valueJsonString);

            _distributedCache.Set(
                key,
                valueByteArray,
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
            byte[] valueByteArray = _distributedCache.GetAsync(key).Result;

            string valueJsonString = (valueByteArray is not null) ? Encoding.UTF8.GetString(valueByteArray) : string.Empty;

            T value = !string.IsNullOrWhiteSpace(valueJsonString) ? JsonSerializer.Deserialize<T>(valueJsonString) : default;

            return value;
        }
    }
}