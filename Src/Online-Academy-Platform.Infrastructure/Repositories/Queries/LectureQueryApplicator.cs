using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories.Queries;

internal static class LectureQueryApplicator
{
    public static IQueryable<Lecture> Apply(IQueryable<Lecture> query, LectureQuery parameters)
    {
        if (parameters.CourseId.HasValue)
            query = query.Where(l => l.CourseId == parameters.CourseId.Value);
        if (parameters.LectureAfter.HasValue)
            query = query.Where(l => l.LectureDate >= parameters.LectureAfter.Value);
        if (parameters.LectureBefore.HasValue)
            query = query.Where(l => l.LectureDate <= parameters.LectureBefore.Value);
        if (parameters.MinDuration.HasValue)
            query = query.Where(l => l.DurationMinutes >= parameters.MinDuration.Value);
        if (parameters.MaxDuration.HasValue)
            query = query.Where(l => l.DurationMinutes <= parameters.MaxDuration.Value);

        if (parameters.Sorts.Count == 0)
            return query.OrderBy(l => l.Id);

        IOrderedQueryable<Lecture>? ordered = null;
        foreach (var sort in parameters.Sorts)
        {
            ordered = (ordered, sort.Direction, sort.PropertyName) switch
            {
                (null, SortDirection.Asc, LectureSortField.Id) => query.OrderBy(l => l.Id),
                (null, SortDirection.Desc, LectureSortField.Id) => query.OrderByDescending(l => l.Id),
                (null, SortDirection.Asc, LectureSortField.CourseId) => query.OrderBy(l => l.CourseId),
                (null, SortDirection.Desc, LectureSortField.CourseId) => query.OrderByDescending(l => l.CourseId),
                (null, SortDirection.Asc, LectureSortField.Title) => query.OrderBy(l => l.Title),
                (null, SortDirection.Desc, LectureSortField.Title) => query.OrderByDescending(l => l.Title),
                (null, SortDirection.Asc, LectureSortField.LectureDate) => query.OrderBy(l => l.LectureDate),
                (null, SortDirection.Desc, LectureSortField.LectureDate) => query.OrderByDescending(l => l.LectureDate),
                (null, SortDirection.Asc, LectureSortField.DurationMinutes) => query.OrderBy(l => l.DurationMinutes),
                (null, SortDirection.Desc, LectureSortField.DurationMinutes) => query.OrderByDescending(l => l.DurationMinutes),
                (var o, SortDirection.Asc, LectureSortField.Id) => o.ThenBy(l => l.Id),
                (var o, SortDirection.Desc, LectureSortField.Id) => o.ThenByDescending(l => l.Id),
                (var o, SortDirection.Asc, LectureSortField.CourseId) => o.ThenBy(l => l.CourseId),
                (var o, SortDirection.Desc, LectureSortField.CourseId) => o.ThenByDescending(l => l.CourseId),
                (var o, SortDirection.Asc, LectureSortField.Title) => o.ThenBy(l => l.Title),
                (var o, SortDirection.Desc, LectureSortField.Title) => o.ThenByDescending(l => l.Title),
                (var o, SortDirection.Asc, LectureSortField.LectureDate) => o.ThenBy(l => l.LectureDate),
                (var o, SortDirection.Desc, LectureSortField.LectureDate) => o.ThenByDescending(l => l.LectureDate),
                (var o, SortDirection.Asc, LectureSortField.DurationMinutes) => o.ThenBy(l => l.DurationMinutes),
                (var o, SortDirection.Desc, LectureSortField.DurationMinutes) => o.ThenByDescending(l => l.DurationMinutes),
                _ => ordered ?? query.OrderBy(l => l.Id)
            };
        }
        return ordered ?? query;
    }
}