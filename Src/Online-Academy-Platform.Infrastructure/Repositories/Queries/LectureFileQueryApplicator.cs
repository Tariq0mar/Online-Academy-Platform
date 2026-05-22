using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories.Queries;

internal static class LectureFileQueryApplicator
{
    public static IQueryable<LectureFile> Apply(IQueryable<LectureFile> query, LectureFileQuery parameters)
    {
        if (parameters.LectureId.HasValue)
            query = query.Where(f => f.LectureId == parameters.LectureId.Value);
        if (parameters.FileType.HasValue)
            query = query.Where(f => f.FileType == parameters.FileType.Value);

        if (parameters.Sorts.Count == 0)
            return query.OrderBy(f => f.Id);

        IOrderedQueryable<LectureFile>? ordered = null;
        foreach (var sort in parameters.Sorts)
        {
            ordered = (ordered, sort.Direction, sort.PropertyName) switch
            {
                (null, SortDirection.Asc, LectureFileSortField.Id) => query.OrderBy(f => f.Id),
                (null, SortDirection.Desc, LectureFileSortField.Id) => query.OrderByDescending(f => f.Id),
                (null, SortDirection.Asc, LectureFileSortField.LectureId) => query.OrderBy(f => f.LectureId),
                (null, SortDirection.Desc, LectureFileSortField.LectureId) => query.OrderByDescending(f => f.LectureId),
                (null, SortDirection.Asc, LectureFileSortField.FileUrl) => query.OrderBy(f => f.FileUrl),
                (null, SortDirection.Desc, LectureFileSortField.FileUrl) => query.OrderByDescending(f => f.FileUrl),
                (null, SortDirection.Asc, LectureFileSortField.FileType) => query.OrderBy(f => f.FileType),
                (null, SortDirection.Desc, LectureFileSortField.FileType) => query.OrderByDescending(f => f.FileType),
                (var o, SortDirection.Asc, LectureFileSortField.Id) => o.ThenBy(f => f.Id),
                (var o, SortDirection.Desc, LectureFileSortField.Id) => o.ThenByDescending(f => f.Id),
                (var o, SortDirection.Asc, LectureFileSortField.LectureId) => o.ThenBy(f => f.LectureId),
                (var o, SortDirection.Desc, LectureFileSortField.LectureId) => o.ThenByDescending(f => f.LectureId),
                (var o, SortDirection.Asc, LectureFileSortField.FileUrl) => o.ThenBy(f => f.FileUrl),
                (var o, SortDirection.Desc, LectureFileSortField.FileUrl) => o.ThenByDescending(f => f.FileUrl),
                (var o, SortDirection.Asc, LectureFileSortField.FileType) => o.ThenBy(f => f.FileType),
                (var o, SortDirection.Desc, LectureFileSortField.FileType) => o.ThenByDescending(f => f.FileType),
                _ => ordered ?? query.OrderBy(f => f.Id)
            };
        }
        return ordered ?? query;
    }
}