using MediatR;

namespace ProjectWeather.Application.Command.WeatherCommand
{
    public class DeleteWeatherCommand : IRequest<WeatherResponse>
    {
        public string Id { get; set; }
    }
}
