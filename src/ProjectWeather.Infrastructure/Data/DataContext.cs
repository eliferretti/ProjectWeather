using Microsoft.EntityFrameworkCore;
using ProjectWeather.Domain.Entities;
using ProjectWeather.Domain.ValueObjects;

namespace ProjectWeather.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Weather> Weathers { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Current> Currents { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Weather>().HasOne(w => w.Location).WithOne(l => l.Weather).HasForeignKey<Location>(l => l.WeatherId);
            modelBuilder.Entity<Weather>().HasOne(w => w.Current).WithOne(c => c.Weather).HasForeignKey<Current>(c => c.WeatherId);

            modelBuilder.Entity<Current>().HasOne(c => c.Condition).WithOne(c => c.Current).HasForeignKey<Condition>(c => c.CurrentId);
        }
    }
}
