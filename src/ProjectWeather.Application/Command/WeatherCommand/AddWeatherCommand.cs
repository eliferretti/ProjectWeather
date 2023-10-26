using MediatR;
using ProjectWeather.Application.Dto;

namespace ProjectWeather.Application.Command.WeatherCommand
{
    public class AddWeatherCommand : IRequest<WeatherResponse>
    {
        public AddWeatherDto Weather { get; set; }
    }
}
