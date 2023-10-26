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
            CreateMap<Weather, AddWeatherDto>().ReverseMap();
            CreateMap<Location, AddLocationDto>().ReverseMap();
            CreateMap<Condition, AddConditionDto>().ReverseMap();
            CreateMap<Current, AddCurrentDto>().ReverseMap();
        }
    }
}
