using Microsoft.EntityFrameworkCore;
using ProjectWeather.Domain.Entities;
using ProjectWeather.Infrastructure.Data;
using ProjectWeather.Infrastructure.Interfaces;

namespace ProjectWeather.Infrastructure.Repositories
{
    public class WeatherRepository : IRepository<Weather, string> 
    {
        private DataContext _context { get; init; }

        public WeatherRepository(DataContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Weather data)
        {
            await _context.Weathers.AddAsync(data);
            await _context.SaveChangesAsync(); 
        }

        public async Task<Weather> GetSingleAsync(string id)
            => await _context.Weathers.FirstOrDefaultAsync(w => w.Id == id) ?? new Weather { Id = null};

        public async Task UpdateAsync(Weather data)
        {
            _context.Weathers.Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Weather data)
        {
            _context.Weathers.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Weather>> GetAll() 
            => await _context.Weathers.ToListAsync();

    }
}
