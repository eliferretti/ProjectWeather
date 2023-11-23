using MediatR;
using ProjectWeather.Application.Dto;

namespace ProjectWeather.Application.Query
{
    public class GetWeatherByIdQuery : IRequest<WeatherDto>
    {
        public string Id { get; set; }
    }
}
