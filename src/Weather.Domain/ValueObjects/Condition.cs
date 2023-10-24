using System.ComponentModel.DataAnnotations.Schema;
using ProjectWeather.Domain.Entities;

namespace ProjectWeather.Domain.ValueObjects
{
    [Table("Conditions")]
    public class Condition : BaseEntity<string>
    {
        public Condition()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Text { get; set; }
        public string Icon { get; set; }
        public int Code { get; set; }
        public Current Current { get; set; }
    }
}
