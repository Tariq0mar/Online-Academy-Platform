using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories.Queries;

internal static class AttendanceQueryApplicator
{
    public static IQueryable<Attendance> Apply(IQueryable<Attendance> query, AttendanceQuery parameters)
    {
        if (parameters.LectureId.HasValue)
            query = query.Where(a => a.LectureId == parameters.LectureId.Value);
        if (parameters.UserId.HasValue)
            query = query.Where(a => a.UserId == parameters.UserId.Value);
        if (parameters.Status.HasValue)
            query = query.Where(a => a.Status == parameters.Status.Value);

        if (parameters.Sorts.Count == 0)
            return query.OrderBy(a => a.Id);

        IOrderedQueryable<Attendance>? ordered = null;
        foreach (var sort in parameters.Sorts)
        {
            ordered = (ordered, sort.Direction, sort.PropertyName) switch
            {
                (null, SortDirection.Asc, AttendanceSortField.Id) => query.OrderBy(a => a.Id),
                (null, SortDirection.Desc, AttendanceSortField.Id) => query.OrderByDescending(a => a.Id),
                (null, SortDirection.Asc, AttendanceSortField.LectureId) => query.OrderBy(a => a.LectureId),
                (null, SortDirection.Desc, AttendanceSortField.LectureId) => query.OrderByDescending(a => a.LectureId),
                (null, SortDirection.Asc, AttendanceSortField.UserId) => query.OrderBy(a => a.UserId),
                (null, SortDirection.Desc, AttendanceSortField.UserId) => query.OrderByDescending(a => a.UserId),
                (null, SortDirection.Asc, AttendanceSortField.Status) => query.OrderBy(a => a.Status),
                (null, SortDirection.Desc, AttendanceSortField.Status) => query.OrderByDescending(a => a.Status),
                (var o, SortDirection.Asc, AttendanceSortField.Id) => o.ThenBy(a => a.Id),
                (var o, SortDirection.Desc, AttendanceSortField.Id) => o.ThenByDescending(a => a.Id),
                (var o, SortDirection.Asc, AttendanceSortField.LectureId) => o.ThenBy(a => a.LectureId),
                (var o, SortDirection.Desc, AttendanceSortField.LectureId) => o.ThenByDescending(a => a.LectureId),
                (var o, SortDirection.Asc, AttendanceSortField.UserId) => o.ThenBy(a => a.UserId),
                (var o, SortDirection.Desc, AttendanceSortField.UserId) => o.ThenByDescending(a => a.UserId),
                (var o, SortDirection.Asc, AttendanceSortField.Status) => o.ThenBy(a => a.Status),
                (var o, SortDirection.Desc, AttendanceSortField.Status) => o.ThenByDescending(a => a.Status),
                _ => ordered ?? query.OrderBy(a => a.Id)
            };
        }
        return ordered ?? query;
    }
}