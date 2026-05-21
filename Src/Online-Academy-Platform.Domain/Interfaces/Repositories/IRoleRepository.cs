using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface IRoleRepository : IQueryableRepository<Role, RoleQuery>
{
    Task<Role?> GetByNameAsync(string name);

    Task<bool> ExistsByNameAsync(string name);
}
