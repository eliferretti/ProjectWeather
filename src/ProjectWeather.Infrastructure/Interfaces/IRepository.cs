namespace ProjectWeather.Infrastructure.Interfaces
{
    public interface IRepository<T, TId> where T : class
    {
        Task SaveAsync(T Data);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetSingleAsync(TId id);
        Task UpdateAsync(T Data);
        Task DeleteAsync(TId id);
    }
}
