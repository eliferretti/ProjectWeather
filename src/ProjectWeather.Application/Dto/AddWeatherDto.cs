namespace ProjectWeather.Application.Dto
{
    public class AddWeatherDto
    {
        public LocationDto Location { get; set; }
        public CurrentDto Current { get; set; }
    }
}
