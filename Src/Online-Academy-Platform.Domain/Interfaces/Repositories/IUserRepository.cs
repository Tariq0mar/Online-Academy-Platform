using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> AddAsync(User user);

    Task<User?> GetByIdAsync(int id);

    Task<User?> GetByEmailAsync(string email);

    Task<IEnumerable<User>> GetAllAsync();

    Task<IEnumerable<User>> QueryAsync(UserQuery query);

    Task UpdateAsync(User user);

    Task DeleteAsync(int id);

    Task<bool> ExistsByEmailAsync(string email);
}