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
            List<Country> countriesFromCache = cacheHelper.GetFromCache<List<Country>>(_countriesKey);

            if (countriesFromCache is null)
            {
                lock (_countriesLock)
                {
                    countriesFromCache = cacheHelper.GetFromCache<List<Country>>(_countriesKey);

                    if (countriesFromCache is null)
                    {
                        countriesFromCache = getCountriesDelegate(); //func();

                        cacheHelper.AddToCache(_countriesKey, countriesFromCache, TimeSpan.FromHours(1));
                    }
                }
            }

            return countriesFromCache;
        }
    }
}