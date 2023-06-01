using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RCA.Core;
using RCA.Model;

namespace RCA.Business
{
    public class CountryBusiness : Business<Country>
    {
        private readonly ICacheHelper _cacheHelper;
        private readonly IMapper _mapper;

        public CountryBusiness(IRepository<Country> repository, ICacheHelper cacheHelper, IMapper mapper) : base(repository)
        {
            _cacheHelper = cacheHelper;
            _mapper = mapper;
        }

        internal List<Country> GetCountries()
        {
            List<Country> countries = Queryable().Where(s => s.IsActive).AsNoTracking().ToList();

            return countries;
        }
        public List<CountryDto> GetCountriesFromCache()
        {
            List<Country> countriesFromCache = CountryCacheBusiness.GetCountries(_cacheHelper, GetCountries);

            return _mapper.Map<List<CountryDto>>(countriesFromCache);
        }
        public void ClearCache()
        {
            CountryCacheBusiness.RemoveCountriesFromCache(_cacheHelper);
        }
    }
}