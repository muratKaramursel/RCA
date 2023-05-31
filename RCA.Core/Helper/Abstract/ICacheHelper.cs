namespace RCA.Core
{
    public interface ICacheHelper
    {
        void AddToCache(string key, object value, TimeSpan? expireTimeSpan);
        void RemoveFromCache(string key);
        T GetFromCache<T>(string key);
    }
}