using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories.Queries;

internal static class NotificationQueryApplicator
{
    public static IQueryable<Notification> Apply(IQueryable<Notification> query, NotificationQuery parameters)
    {
        if (parameters.UserId.HasValue)
            query = query.Where(n => n.UserId == parameters.UserId.Value);
        if (parameters.IsRead.HasValue)
            query = query.Where(n => n.IsRead == parameters.IsRead.Value);
        if (parameters.CreatedAfter.HasValue)
            query = query.Where(n => n.CreatedAt >= parameters.CreatedAfter.Value);
        if (parameters.CreatedBefore.HasValue)
            query = query.Where(n => n.CreatedAt <= parameters.CreatedBefore.Value);

        if (parameters.Sorts.Count == 0)
            return query.OrderBy(n => n.Id);

        IOrderedQueryable<Notification>? ordered = null;
        foreach (var sort in parameters.Sorts)
        {
            ordered = (ordered, sort.Direction, sort.PropertyName) switch
            {
                (null, SortDirection.Asc, NotificationSortField.Id) => query.OrderBy(n => n.Id),
                (null, SortDirection.Desc, NotificationSortField.Id) => query.OrderByDescending(n => n.Id),
                (null, SortDirection.Asc, NotificationSortField.UserId) => query.OrderBy(n => n.UserId),
                (null, SortDirection.Desc, NotificationSortField.UserId) => query.OrderByDescending(n => n.UserId),
                (null, SortDirection.Asc, NotificationSortField.Title) => query.OrderBy(n => n.Title),
                (null, SortDirection.Desc, NotificationSortField.Title) => query.OrderByDescending(n => n.Title),
                (null, SortDirection.Asc, NotificationSortField.IsRead) => query.OrderBy(n => n.IsRead),
                (null, SortDirection.Desc, NotificationSortField.IsRead) => query.OrderByDescending(n => n.IsRead),
                (null, SortDirection.Asc, NotificationSortField.CreatedAt) => query.OrderBy(n => n.CreatedAt),
                (null, SortDirection.Desc, NotificationSortField.CreatedAt) => query.OrderByDescending(n => n.CreatedAt),
                (var o, SortDirection.Asc, NotificationSortField.Id) => o.ThenBy(n => n.Id),
                (var o, SortDirection.Desc, NotificationSortField.Id) => o.ThenByDescending(n => n.Id),
                (var o, SortDirection.Asc, NotificationSortField.UserId) => o.ThenBy(n => n.UserId),
                (var o, SortDirection.Desc, NotificationSortField.UserId) => o.ThenByDescending(n => n.UserId),
                (var o, SortDirection.Asc, NotificationSortField.Title) => o.ThenBy(n => n.Title),
                (var o, SortDirection.Desc, NotificationSortField.Title) => o.ThenByDescending(n => n.Title),
                (var o, SortDirection.Asc, NotificationSortField.IsRead) => o.ThenBy(n => n.IsRead),
                (var o, SortDirection.Desc, NotificationSortField.IsRead) => o.ThenByDescending(n => n.IsRead),
                (var o, SortDirection.Asc, NotificationSortField.CreatedAt) => o.ThenBy(n => n.CreatedAt),
                (var o, SortDirection.Desc, NotificationSortField.CreatedAt) => o.ThenByDescending(n => n.CreatedAt),
                _ => ordered ?? query.OrderBy(n => n.Id)
            };
        }
        return ordered ?? query;
    }
}