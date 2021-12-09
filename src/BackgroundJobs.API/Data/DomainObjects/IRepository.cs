namespace BackgroundJobs.API.Data.DomainObjects;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    Task<T> GetByIdAsync(Guid id);
    Task<List<T>> GetAllAsync();
    Task UpdateAsync(T obj);
    Task AddAsync(T obj);
    Task RemoveAsync(T obj);
    Task SaveAsync();
}
