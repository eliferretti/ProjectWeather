using ProjectWeather.Domain.ValueObjects;

namespace ProjectWeather.Domain.Entities
{
    public class Weather : BaseEntity<string>
    {
        public Weather() 
        {
            Id = Guid.NewGuid().ToString();
            Time = DateTime.Now;
        }
        public DateTime Time { get; set; } 
        public Location Location { get; set; }
        public Current Current { get; set; } 
    }
}
