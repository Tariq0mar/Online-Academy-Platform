using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories.Queries;

internal static class UserQueryApplicator
{
    public static IQueryable<User> Apply(IQueryable<User> query, UserQuery parameters)
    {
        if (parameters.Active.HasValue)
        {
            query = query.Where(u => u.Active == parameters.Active.Value);
        }

        if (parameters.Role.HasValue)
        {
            query = query.Where(u => u.Role == parameters.Role.Value);
        }

        if (parameters.CreatedAfter.HasValue)
        {
            query = query.Where(u => u.CreatedAt >= parameters.CreatedAfter.Value);
        }

        if (parameters.CreatedBefore.HasValue)
        {
            query = query.Where(u => u.CreatedAt <= parameters.CreatedBefore.Value);
        }

        return ApplySort(query, parameters.Sorts);
    }

    private static IQueryable<User> ApplySort(IQueryable<User> query, List<SortCriteria<UserSortField>> sorts)
    {
        if (sorts.Count == 0)
        {
            return query.OrderBy(u => u.Id);
        }

        IOrderedQueryable<User>? ordered = null;
        foreach (var sort in sorts)
        {
            ordered = (ordered, sort.Direction, sort.PropertyName) switch
            {
                (null, SortDirection.Asc, UserSortField.Id) => query.OrderBy(u => u.Id),
                (null, SortDirection.Desc, UserSortField.Id) => query.OrderByDescending(u => u.Id),
                (null, SortDirection.Asc, UserSortField.Name) => query.OrderBy(u => u.Name),
                (null, SortDirection.Desc, UserSortField.Name) => query.OrderByDescending(u => u.Name),
                (null, SortDirection.Asc, UserSortField.Email) => query.OrderBy(u => u.Email),
                (null, SortDirection.Desc, UserSortField.Email) => query.OrderByDescending(u => u.Email),
                (null, SortDirection.Asc, UserSortField.Phone) => query.OrderBy(u => u.Phone),
                (null, SortDirection.Desc, UserSortField.Phone) => query.OrderByDescending(u => u.Phone),
                (null, SortDirection.Asc, UserSortField.Active) => query.OrderBy(u => u.Active),
                (null, SortDirection.Desc, UserSortField.Active) => query.OrderByDescending(u => u.Active),
                (null, SortDirection.Asc, UserSortField.Role) => query.OrderBy(u => u.Role),
                (null, SortDirection.Desc, UserSortField.Role) => query.OrderByDescending(u => u.Role),
                (null, SortDirection.Asc, UserSortField.CreatedAt) => query.OrderBy(u => u.CreatedAt),
                (null, SortDirection.Desc, UserSortField.CreatedAt) => query.OrderByDescending(u => u.CreatedAt),
                (var o, SortDirection.Asc, UserSortField.Id) => o.ThenBy(u => u.Id),
                (var o, SortDirection.Desc, UserSortField.Id) => o.ThenByDescending(u => u.Id),
                (var o, SortDirection.Asc, UserSortField.Name) => o.ThenBy(u => u.Name),
                (var o, SortDirection.Desc, UserSortField.Name) => o.ThenByDescending(u => u.Name),
                (var o, SortDirection.Asc, UserSortField.Email) => o.ThenBy(u => u.Email),
                (var o, SortDirection.Desc, UserSortField.Email) => o.ThenByDescending(u => u.Email),
                (var o, SortDirection.Asc, UserSortField.Phone) => o.ThenBy(u => u.Phone),
                (var o, SortDirection.Desc, UserSortField.Phone) => o.ThenByDescending(u => u.Phone),
                (var o, SortDirection.Asc, UserSortField.Active) => o.ThenBy(u => u.Active),
                (var o, SortDirection.Desc, UserSortField.Active) => o.ThenByDescending(u => u.Active),
                (var o, SortDirection.Asc, UserSortField.Role) => o.ThenBy(u => u.Role),
                (var o, SortDirection.Desc, UserSortField.Role) => o.ThenByDescending(u => u.Role),
                (var o, SortDirection.Asc, UserSortField.CreatedAt) => o.ThenBy(u => u.CreatedAt),
                (var o, SortDirection.Desc, UserSortField.CreatedAt) => o.ThenByDescending(u => u.CreatedAt),
                _ => ordered ?? query.OrderBy(u => u.Id)
            };
        }

        return ordered ?? query;
    }
}
