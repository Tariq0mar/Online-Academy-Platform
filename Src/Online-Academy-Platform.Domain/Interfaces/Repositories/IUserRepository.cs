using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<IEnumerable<User>> QueryAsync();
}