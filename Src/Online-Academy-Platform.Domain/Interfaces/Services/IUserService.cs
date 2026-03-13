using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface IUserService: IService<User>
{
    Task<User> QueryAsync(UserQuery query);
}