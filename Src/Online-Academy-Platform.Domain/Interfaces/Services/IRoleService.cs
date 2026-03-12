using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface IRoleService: IService<Role>
{
    Task<Role> QueryAsync(RoleQuery query);
}