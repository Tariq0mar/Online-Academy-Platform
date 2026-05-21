namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface ISearchableService<T, in TQuery> : IService<T>
{
    Task<IEnumerable<T>> QueryAsync(TQuery query);
}
