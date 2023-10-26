using System.ComponentModel.DataAnnotations.Schema;
using ProjectWeather.Domain.ValueObjects;

namespace ProjectWeather.Domain.Entities
{
    [Table("Weathers")]
    public class Weather : BaseEntity<string>
    {
        public Weather() 
        {
            Id = Guid.NewGuid().ToString();
        }
        public DateTime Time { get; set; } = DateTime.Now;
        public Location Location { get; set; }
        public Current Current { get; set; } 
    }
}
