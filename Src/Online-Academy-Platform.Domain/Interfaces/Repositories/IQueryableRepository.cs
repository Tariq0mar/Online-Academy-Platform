using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface IQueryableRepository<T, in TQuery> : IRepository<T>
{
    Task<IEnumerable<T>> QueryAsync(TQuery query);

    Task<PagedResult<T>> QueryPagedAsync(TQuery query);
}
