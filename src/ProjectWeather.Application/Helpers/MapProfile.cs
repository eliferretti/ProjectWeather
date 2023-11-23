using AutoMapper;
using ProjectWeather.Application.Dto;
using ProjectWeather.Domain.Entities;
using ProjectWeather.Domain.ValueObjects;

namespace ProjectWeather.Application.Helpers
{
    public class MapProfile : Profile
    {
        public MapProfile() 
        {
            CreateMap<Weather, WeatherDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Condition, ConditionDto>().ReverseMap();
            CreateMap<Current, CurrentDto>().ReverseMap();
            CreateMap<Weather, AddWeatherDto>().ReverseMap();
        }
    }
}
