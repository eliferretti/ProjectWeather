using ProjectWeather.Domain.ValueObjects;

namespace ProjectWeather.Application.Dto
{
    public class AddWeatherDto
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }
}
