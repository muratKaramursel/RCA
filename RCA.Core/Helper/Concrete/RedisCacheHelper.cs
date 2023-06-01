using StackExchange.Redis;
using System.Text.Json;

namespace RCA.Core
{
    public class RedisCacheHelper : ICacheHelper
    {
        private readonly IDatabase _redisDatabase;

        public RedisCacheHelper()
        {
            ConfigurationHelper.ParseConfigrationValue("ConnectionStrings:Redis", out string redisConnectionString);

            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);

            _redisDatabase = connectionMultiplexer.GetDatabase();
        }

        public void AddToCache(string key, object value, TimeSpan? expireTimeSpan)
        {
            string valueJsonString = JsonSerializer.Serialize(value);

            _redisDatabase.StringSet(key, valueJsonString, expireTimeSpan);
        }
        public void RemoveFromCache(string key)
        {
            _redisDatabase.KeyDelete(key);
        }
        public T GetFromCache<T>(string key)
        {
            string valueJsonString = _redisDatabase.StringGet(key);

            T value = !string.IsNullOrWhiteSpace(valueJsonString) ? JsonSerializer.Deserialize<T>(valueJsonString) : default;

            return value;
        }
    }
}