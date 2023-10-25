using ProjectWeather.Domain.Entities;
using ProjectWeather.Infrastructure.Data;
using ProjectWeather.Infrastructure.Interfaces;

namespace ProjectWeather.Infrastructure.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private DataContext _context { get; init; }

        public WeatherRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Weather weather)
        {
            await _context.Weathers.AddAsync(weather);
            await _context.SaveChangesAsync();
        }
    }
}
