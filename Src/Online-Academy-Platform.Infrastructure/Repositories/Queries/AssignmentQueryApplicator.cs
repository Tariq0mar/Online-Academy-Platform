using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories.Queries;

internal static class AssignmentQueryApplicator
{
    public static IQueryable<Assignment> Apply(IQueryable<Assignment> query, AssignmentQuery parameters)
    {
        if (parameters.CourseId.HasValue)
            query = query.Where(a => a.CourseId == parameters.CourseId.Value);
        if (parameters.MinMaxGrade.HasValue)
            query = query.Where(a => a.MaxGrade >= parameters.MinMaxGrade.Value);
        if (parameters.MaxMaxGrade.HasValue)
            query = query.Where(a => a.MaxGrade <= parameters.MaxMaxGrade.Value);
        if (parameters.CreatedAfter.HasValue)
            query = query.Where(a => a.CreatedAt >= parameters.CreatedAfter.Value);
        if (parameters.CreatedBefore.HasValue)
            query = query.Where(a => a.CreatedAt <= parameters.CreatedBefore.Value);
        if (parameters.DeadlineAfter.HasValue)
            query = query.Where(a => a.Deadline >= parameters.DeadlineAfter.Value);
        if (parameters.DeadlineBefore.HasValue)
            query = query.Where(a => a.Deadline <= parameters.DeadlineBefore.Value);

        if (parameters.Sorts.Count == 0)
            return query.OrderBy(a => a.Id);

        IOrderedQueryable<Assignment>? ordered = null;
        foreach (var sort in parameters.Sorts)
        {
            ordered = (ordered, sort.Direction, sort.PropertyName) switch
            {
                (null, SortDirection.Asc, AssignmentSortField.Id) => query.OrderBy(a => a.Id),
                (null, SortDirection.Desc, AssignmentSortField.Id) => query.OrderByDescending(a => a.Id),
                (null, SortDirection.Asc, AssignmentSortField.Title) => query.OrderBy(a => a.Title),
                (null, SortDirection.Desc, AssignmentSortField.Title) => query.OrderByDescending(a => a.Title),
                (null, SortDirection.Asc, AssignmentSortField.MaxGrade) => query.OrderBy(a => a.MaxGrade),
                (null, SortDirection.Desc, AssignmentSortField.MaxGrade) => query.OrderByDescending(a => a.MaxGrade),
                (null, SortDirection.Asc, AssignmentSortField.Deadline) => query.OrderBy(a => a.Deadline),
                (null, SortDirection.Desc, AssignmentSortField.Deadline) => query.OrderByDescending(a => a.Deadline),
                (null, SortDirection.Asc, AssignmentSortField.CreatedAt) => query.OrderBy(a => a.CreatedAt),
                (null, SortDirection.Desc, AssignmentSortField.CreatedAt) => query.OrderByDescending(a => a.CreatedAt),
                (null, SortDirection.Asc, AssignmentSortField.CourseId) => query.OrderBy(a => a.CourseId),
                (null, SortDirection.Desc, AssignmentSortField.CourseId) => query.OrderByDescending(a => a.CourseId),
                (var o, SortDirection.Asc, AssignmentSortField.Id) => o.ThenBy(a => a.Id),
                (var o, SortDirection.Desc, AssignmentSortField.Id) => o.ThenByDescending(a => a.Id),
                (var o, SortDirection.Asc, AssignmentSortField.Title) => o.ThenBy(a => a.Title),
                (var o, SortDirection.Desc, AssignmentSortField.Title) => o.ThenByDescending(a => a.Title),
                (var o, SortDirection.Asc, AssignmentSortField.MaxGrade) => o.ThenBy(a => a.MaxGrade),
                (var o, SortDirection.Desc, AssignmentSortField.MaxGrade) => o.ThenByDescending(a => a.MaxGrade),
                (var o, SortDirection.Asc, AssignmentSortField.Deadline) => o.ThenBy(a => a.Deadline),
                (var o, SortDirection.Desc, AssignmentSortField.Deadline) => o.ThenByDescending(a => a.Deadline),
                (var o, SortDirection.Asc, AssignmentSortField.CreatedAt) => o.ThenBy(a => a.CreatedAt),
                (var o, SortDirection.Desc, AssignmentSortField.CreatedAt) => o.ThenByDescending(a => a.CreatedAt),
                (var o, SortDirection.Asc, AssignmentSortField.CourseId) => o.ThenBy(a => a.CourseId),
                (var o, SortDirection.Desc, AssignmentSortField.CourseId) => o.ThenByDescending(a => a.CourseId),
                _ => ordered ?? query.OrderBy(a => a.Id)
            };
        }
        return ordered ?? query;
    }
}