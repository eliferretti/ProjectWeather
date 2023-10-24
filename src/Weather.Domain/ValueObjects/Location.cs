using System.ComponentModel.DataAnnotations.Schema;
using ProjectWeather.Domain.Entities;

namespace ProjectWeather.Domain.ValueObjects
{
    [Table("Locations")]
    public class Location : BaseEntity<string>
    {
        public Location()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public string Tz_id { get; set; }
        public int Localtime_epoch { get; set; }
        public string Localtime { get; set; }
        public Weather Weather { get; set; }
    }
}
