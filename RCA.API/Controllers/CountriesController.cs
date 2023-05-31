using Microsoft.AspNetCore.Mvc;
using RCA.Business;
using RCA.Model;

namespace RCA.API.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly CountryBusiness _countryBusiness;

        public CountriesController(CountryBusiness countryBusiness)
        {
            _countryBusiness = countryBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            List<CountryDto> countryDtos = _countryBusiness.GetCountriesFromCache();

            return await Task.FromResult(Ok(countryDtos));
        }
    }
}