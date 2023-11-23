namespace ProjectWeather.Application.Dto
{
    public class WeatherDto
    {
        public string Id { get; set; }
        public LocationDto Location { get; set; }
        public CurrentDto Current { get; set; }
    }
}
