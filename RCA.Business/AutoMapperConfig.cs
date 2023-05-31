using AutoMapper;
using RCA.Model;

namespace RCA.Business
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            MapperConfiguration mapperConfiguration = new(config =>
            {
                config.CreateMap<Country, CountryDto>().ReverseMap();
            });

            return mapperConfiguration;
        }
    }
}