using ProjectWeather.Domain.Entities;

namespace ProjectWeather.Infrastructure.Interfaces
{
    public interface IWeatherRepository
    {
        Task AddAsync(Weather weather);
    }
}
