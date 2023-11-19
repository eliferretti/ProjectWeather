namespace ProjectWeather.Infrastructure.Interfaces
{
    public interface IRepository<T, TId> where T : class
    {
        Task SaveAsync(T data);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingleAsync(TId id);
        Task UpdateAsync(T data);
        Task DeleteAsync(TId id);
    }
}
