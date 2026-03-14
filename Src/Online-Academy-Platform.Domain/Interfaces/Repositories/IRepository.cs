namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface IRepository<T>
{
    Task<T> AddAsync(T entity);
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}