using ProjectWeather.Domain.Entities;
using ProjectWeather.Infrastructure.Data;
using ProjectWeather.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProjectWeather.Infrastructure.Repositories
{
    public class WeatherRepository : IRepository<Weather, string>
    {
        private DataContext _context { get; init; }

        public WeatherRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(string id)
        {
            try 
            {
                var weather = _context.Weathers.FirstOrDefault(x => x.Id == id);
                if (weather != null) 
                {
                    _context.Weathers.Remove(weather);
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception ex) { }
        }

        public async Task<IEnumerable<Weather>> GetAllAsync() 
            => await _context.Weathers.Include(l => l.Location).Include(c => c.Current).ToListAsync();

        public async Task<Weather> GetSingleAsync(string id)
            => await _context.Weathers.Include(c => c.Current).Include(l => l.Location).FirstOrDefaultAsync(w => w.Id == id) ?? new Weather();
        
        public async Task SaveAsync(Weather data)
        {
            try 
            {
                await _context.Weathers.AddAsync(data);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex) { }
        }

        public async Task UpdateAsync(Weather data)
        {
            try 
            {
                _context.Weathers.Update(data);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex) { }
        }
    }
}
