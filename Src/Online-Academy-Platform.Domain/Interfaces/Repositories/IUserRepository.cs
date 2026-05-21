using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface IUserRepository : IQueryableRepository<User, UserQuery>
{
    Task<User?> GetByEmailAsync(string email);

    Task<bool> ExistsByEmailAsync(string email);

    Task<bool> ExistsByEmailAsync(string email, int excludeUserId);

    Task<IEnumerable<User>> GetByRoleAsync(UserRole role);
}
