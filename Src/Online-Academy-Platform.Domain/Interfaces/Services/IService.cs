namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface IService<T>
{
    Task<T> AddAsync(T entity);

    Task<T?> GetByIdAsync(int id);

    Task<IEnumerable<T>> GetAllAsync();

    Task<bool> ExistsAsync(int id);

    Task UpdateAsync(T entity);

    Task DeleteAsync(int id);
}
