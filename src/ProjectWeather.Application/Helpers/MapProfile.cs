using AutoMapper;
using ProjectWeather.Application.Dto;
using ProjectWeather.Domain.Entities;

namespace ProjectWeather.Application.Helpers
{
    public class MapProfile : Profile
    {
        public MapProfile() 
        {
            CreateMap<Weather, AddWeatherDto>();
        }
    }
}
