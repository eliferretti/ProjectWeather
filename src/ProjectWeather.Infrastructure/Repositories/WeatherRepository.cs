using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using ProjectWeather.Domain.Entities;
using ProjectWeather.Infrastructure.Data;
using ProjectWeather.Infrastructure.Interfaces;
using ProjectWeather.Infrastructure.Migrations;

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
            try 
            {
                await _context.Weathers.AddAsync(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }


        public Task<Weather> GetSingleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Weather Data)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Weather>> GetAll() => await _context.Weathers.ToListAsync();

    }
}
