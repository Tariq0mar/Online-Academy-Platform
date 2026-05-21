using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories.Queries;

internal static class EnrollmentQueryApplicator
{
    public static IQueryable<Enrollment> Apply(IQueryable<Enrollment> query, EnrollmentQuery parameters)
    {
        if (parameters.UserId.HasValue)
            query = query.Where(e => e.UserId == parameters.UserId.Value);
        if (parameters.CourseId.HasValue)
            query = query.Where(e => e.CourseId == parameters.CourseId.Value);
        if (parameters.Status.HasValue)
            query = query.Where(e => e.Status == parameters.Status.Value);
        if (parameters.EnrolledAfter.HasValue)
            query = query.Where(e => e.EnrolledAt >= parameters.EnrolledAfter.Value);
        if (parameters.EnrolledBefore.HasValue)
            query = query.Where(e => e.EnrolledAt <= parameters.EnrolledBefore.Value);

        return ApplySort(query, parameters.Sorts);
    }

    private static IQueryable<Enrollment> ApplySort(IQueryable<Enrollment> query, List<SortCriteria<EnrollmentSortField>> sorts)
    {
        if (sorts.Count == 0)
            return query.OrderBy(e => e.Id);

        IOrderedQueryable<Enrollment>? ordered = null;
        foreach (var sort in sorts)
        {
            ordered = (ordered, sort.Direction, sort.PropertyName) switch
            {
                (null, SortDirection.Asc, EnrollmentSortField.Id) => query.OrderBy(e => e.Id),
                (null, SortDirection.Desc, EnrollmentSortField.Id) => query.OrderByDescending(e => e.Id),
                (null, SortDirection.Asc, EnrollmentSortField.UserId) => query.OrderBy(e => e.UserId),
                (null, SortDirection.Desc, EnrollmentSortField.UserId) => query.OrderByDescending(e => e.UserId),
                (null, SortDirection.Asc, EnrollmentSortField.CourseId) => query.OrderBy(e => e.CourseId),
                (null, SortDirection.Desc, EnrollmentSortField.CourseId) => query.OrderByDescending(e => e.CourseId),
                (null, SortDirection.Asc, EnrollmentSortField.Status) => query.OrderBy(e => e.Status),
                (null, SortDirection.Desc, EnrollmentSortField.Status) => query.OrderByDescending(e => e.Status),
                (null, SortDirection.Asc, EnrollmentSortField.EnrolledAt) => query.OrderBy(e => e.EnrolledAt),
                (null, SortDirection.Desc, EnrollmentSortField.EnrolledAt) => query.OrderByDescending(e => e.EnrolledAt),
                (var o, SortDirection.Asc, EnrollmentSortField.Id) => o.ThenBy(e => e.Id),
                (var o, SortDirection.Desc, EnrollmentSortField.Id) => o.ThenByDescending(e => e.Id),
                (var o, SortDirection.Asc, EnrollmentSortField.UserId) => o.ThenBy(e => e.UserId),
                (var o, SortDirection.Desc, EnrollmentSortField.UserId) => o.ThenByDescending(e => e.UserId),
                (var o, SortDirection.Asc, EnrollmentSortField.CourseId) => o.ThenBy(e => e.CourseId),
                (var o, SortDirection.Desc, EnrollmentSortField.CourseId) => o.ThenByDescending(e => e.CourseId),
                (var o, SortDirection.Asc, EnrollmentSortField.Status) => o.ThenBy(e => e.Status),
                (var o, SortDirection.Desc, EnrollmentSortField.Status) => o.ThenByDescending(e => e.Status),
                (var o, SortDirection.Asc, EnrollmentSortField.EnrolledAt) => o.ThenBy(e => e.EnrolledAt),
                (var o, SortDirection.Desc, EnrollmentSortField.EnrolledAt) => o.ThenByDescending(e => e.EnrolledAt),
                _ => ordered ?? query.OrderBy(e => e.Id)
            };
        }

        return ordered ?? query;
    }
}
