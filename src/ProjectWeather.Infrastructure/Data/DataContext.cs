using Microsoft.EntityFrameworkCore;
using ProjectWeather.Domain.Entities;
using ProjectWeather.Domain.ValueObjects;

namespace ProjectWeather.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Weather> Weathers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    
            modelBuilder.Entity<Weather>().ToContainer("weather").HasPartitionKey(p => p.Id);
        }
    }
}
