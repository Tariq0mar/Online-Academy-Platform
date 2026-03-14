using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface IRoleRepository : IRepository<Role>
{
    Task<IEnumerable<Role>> QueryAsync();
}