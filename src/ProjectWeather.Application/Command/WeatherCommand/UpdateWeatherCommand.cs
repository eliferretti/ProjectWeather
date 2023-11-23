using MediatR;
using ProjectWeather.Application.Dto;

namespace ProjectWeather.Application.Command.WeatherCommand
{
    public class UpdateWeatherCommand : IRequest<WeatherResponse>
    {
        public WeatherDto Weather { get; set; }
    }
}
