namespace ProjectWeather.Domain.Interfaces
{
    public interface IRepository<T, TId> where T : class
    {
        Task SaveAsync(T Data);
        Task UpdateAsync(T Data);
        Task DeleteAsync(TId id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetSingleAsync(TId id);
    }
}
