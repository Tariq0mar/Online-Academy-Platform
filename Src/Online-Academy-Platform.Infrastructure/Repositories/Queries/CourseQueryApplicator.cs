using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories.Queries;

internal static class CourseQueryApplicatorx
{
    public static IQueryable<Course> Apply(IQueryable<Course> query, CourseQuery parameters)
    {
        if (parameters.MinPrice.HasValue)
            query = query.Where(c => c.Price >= parameters.MinPrice.Value);
        if (parameters.MaxPrice.HasValue)
            query = query.Where(c => c.Price <= parameters.MaxPrice.Value);
        if (parameters.Currency.HasValue)
            query = query.Where(c => c.Currency == parameters.Currency.Value);
        if (parameters.MinDuration.HasValue)
            query = query.Where(c => c.DurationHours >= parameters.MinDuration.Value);
        if (parameters.MaxDuration.HasValue)
            query = query.Where(c => c.DurationHours <= parameters.MaxDuration.Value);
        if (parameters.Level.HasValue)
            query = query.Where(c => c.Level == parameters.Level.Value);
        if (parameters.Status.HasValue)
            query = query.Where(c => c.Status == parameters.Status.Value);
        if (parameters.CreatedAfter.HasValue)
            query = query.Where(c => c.CreatedAt >= parameters.CreatedAfter.Value);
        if (parameters.CreatedBefore.HasValue)
            query = query.Where(c => c.CreatedAt <= parameters.CreatedBefore.Value);

        return ApplySort(query, parameters.Sorts);
    }

    private static IQueryable<Course> ApplySort(IQueryable<Course> query, List<SortCriteria<CourseSortField>> sorts)
    {
        if (sorts.Count == 0)
            return query.OrderBy(c => c.Id);

        IOrderedQueryable<Course>? ordered = null;
        foreach (var sort in sorts)
        {
            ordered = (ordered, sort.Direction, sort.PropertyName) switch
            {
                (null, SortDirection.Asc, CourseSortField.Id) => query.OrderBy(c => c.Id),
                (null, SortDirection.Desc, CourseSortField.Id) => query.OrderByDescending(c => c.Id),
                (null, SortDirection.Asc, CourseSortField.Title) => query.OrderBy(c => c.Title),
                (null, SortDirection.Desc, CourseSortField.Title) => query.OrderByDescending(c => c.Title),
                (null, SortDirection.Asc, CourseSortField.Price) => query.OrderBy(c => c.Price),
                (null, SortDirection.Desc, CourseSortField.Price) => query.OrderByDescending(c => c.Price),
                (null, SortDirection.Asc, CourseSortField.Currency) => query.OrderBy(c => c.Currency),
                (null, SortDirection.Desc, CourseSortField.Currency) => query.OrderByDescending(c => c.Currency),
                (null, SortDirection.Asc, CourseSortField.DurationHours) => query.OrderBy(c => c.DurationHours),
                (null, SortDirection.Desc, CourseSortField.DurationHours) => query.OrderByDescending(c => c.DurationHours),
                (null, SortDirection.Asc, CourseSortField.Level) => query.OrderBy(c => c.Level),
                (null, SortDirection.Desc, CourseSortField.Level) => query.OrderByDescending(c => c.Level),
                (null, SortDirection.Asc, CourseSortField.Status) => query.OrderBy(c => c.Status),
                (null, SortDirection.Desc, CourseSortField.Status) => query.OrderByDescending(c => c.Status),
                (null, SortDirection.Asc, CourseSortField.CreatedAt) => query.OrderBy(c => c.CreatedAt),
                (null, SortDirection.Desc, CourseSortField.CreatedAt) => query.OrderByDescending(c => c.CreatedAt),
                (var o, SortDirection.Asc, CourseSortField.Id) => o.ThenBy(c => c.Id),
                (var o, SortDirection.Desc, CourseSortField.Id) => o.ThenByDescending(c => c.Id),
                (var o, SortDirection.Asc, CourseSortField.Title) => o.ThenBy(c => c.Title),
                (var o, SortDirection.Desc, CourseSortField.Title) => o.ThenByDescending(c => c.Title),
                (var o, SortDirection.Asc, CourseSortField.Price) => o.ThenBy(c => c.Price),
                (var o, SortDirection.Desc, CourseSortField.Price) => o.ThenByDescending(c => c.Price),
                (var o, SortDirection.Asc, CourseSortField.Currency) => o.ThenBy(c => c.Currency),
                (var o, SortDirection.Desc, CourseSortField.Currency) => o.ThenByDescending(c => c.Currency),
                (var o, SortDirection.Asc, CourseSortField.DurationHours) => o.ThenBy(c => c.DurationHours),
                (var o, SortDirection.Desc, CourseSortField.DurationHours) => o.ThenByDescending(c => c.DurationHours),
                (var o, SortDirection.Asc, CourseSortField.Level) => o.ThenBy(c => c.Level),
                (var o, SortDirection.Desc, CourseSortField.Level) => o.ThenByDescending(c => c.Level),
                (var o, SortDirection.Asc, CourseSortField.Status) => o.ThenBy(c => c.Status),
                (var o, SortDirection.Desc, CourseSortField.Status) => o.ThenByDescending(c => c.Status),
                (var o, SortDirection.Asc, CourseSortField.CreatedAt) => o.ThenBy(c => c.CreatedAt),
                (var o, SortDirection.Desc, CourseSortField.CreatedAt) => o.ThenByDescending(c => c.CreatedAt),
                _ => ordered ?? query.OrderBy(c => c.Id)
            };
        }

        return ordered ?? query;
    }
}
