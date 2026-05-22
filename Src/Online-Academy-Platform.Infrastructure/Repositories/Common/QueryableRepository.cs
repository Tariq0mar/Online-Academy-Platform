using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Domain.Queries;
using Online_Academy_Platform.Infrastructure.Persistence;

namespace Online_Academy_Platform.Infrastructure.Repositories.Common;

public abstract class QueryableRepository<T, TQuery>(ApplicationDbContext context)
    : Repository<T>(context), IQueryableRepository<T, TQuery>
    where T : class
{
    protected abstract IQueryable<T> ApplyQuery(IQueryable<T> query, TQuery queryParams);

    public async Task<IEnumerable<T>> QueryAsync(TQuery query) =>
        await ApplyQuery(DbSet.AsQueryable(), query).ToListAsync();

    public async Task<PagedResult<T>> QueryPagedAsync(TQuery query)
    {
        var filtered = ApplyQuery(DbSet.AsQueryable(), query);
        var page = GetPage(query);
        var pageSize = GetPageSize(query);
        var totalCount = await filtered.CountAsync();

        var items = await filtered
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<T>
        {
            Items = items,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }

    protected abstract int GetPage(TQuery query);

    protected abstract int GetPageSize(TQuery query);
}
