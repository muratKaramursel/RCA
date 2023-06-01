using RCA.Core;
using RCA.Model;

namespace RCA.Business
{
    internal static class CountryCacheBusiness
    {
        private static readonly object _countriesLock = new();
        private const string _countriesKey = "Countries";
        internal delegate List<Country> GetCountriesDelegate();

        internal static List<Country> GetCountries(ICacheHelper cacheHelper, GetCountriesDelegate getCountriesDelegate /*, Func<List<Country>> func*/)
        {
            string cacheKey = $"{_countriesKey}_{cacheHelper.GetType()}";

            List<Country> countriesFromCache = cacheHelper.GetFromCache<List<Country>>(cacheKey);

            if (countriesFromCache is null)
            {
                lock (_countriesLock)
                {
                    countriesFromCache = cacheHelper.GetFromCache<List<Country>>(cacheKey);

                    if (countriesFromCache is null)
                    {
                        countriesFromCache = getCountriesDelegate(); //func();

                        cacheHelper.AddToCache(cacheKey, countriesFromCache, TimeSpan.FromHours(1));
                    }
                }
            }

            return countriesFromCache;
        }
    }
}