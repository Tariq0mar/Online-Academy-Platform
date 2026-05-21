using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories.Queries;

internal static class CertificateQueryApplicator
{
    public static IQueryable<Certificate> Apply(IQueryable<Certificate> query, CertificateQuery parameters)
    {
        if (parameters.UserId.HasValue)
            query = query.Where(c => c.UserId == parameters.UserId.Value);
        if (parameters.CourseId.HasValue)
            query = query.Where(c => c.CourseId == parameters.CourseId.Value);
        if (parameters.IssuedAfter.HasValue)
            query = query.Where(c => c.IssueDate >= parameters.IssuedAfter.Value);
        if (parameters.IssuedBefore.HasValue)
            query = query.Where(c => c.IssueDate <= parameters.IssuedBefore.Value);

        if (parameters.Sorts.Count == 0)
            return query.OrderBy(c => c.Id);

        IOrderedQueryable<Certificate>? ordered = null;
        foreach (var sort in parameters.Sorts)
        {
            ordered = (ordered, sort.Direction, sort.PropertyName) switch
            {
                (null, SortDirection.Asc, CertificateSortField.Id) => query.OrderBy(c => c.Id),
                (null, SortDirection.Desc, CertificateSortField.Id) => query.OrderByDescending(c => c.Id),
                (null, SortDirection.Asc, CertificateSortField.UserId) => query.OrderBy(c => c.UserId),
                (null, SortDirection.Desc, CertificateSortField.UserId) => query.OrderByDescending(c => c.UserId),
                (null, SortDirection.Asc, CertificateSortField.CourseId) => query.OrderBy(c => c.CourseId),
                (null, SortDirection.Desc, CertificateSortField.CourseId) => query.OrderByDescending(c => c.CourseId),
                (null, SortDirection.Asc, CertificateSortField.IssueDate) => query.OrderBy(c => c.IssueDate),
                (null, SortDirection.Desc, CertificateSortField.IssueDate) => query.OrderByDescending(c => c.IssueDate),
                (var o, SortDirection.Asc, CertificateSortField.Id) => o.ThenBy(c => c.Id),
                (var o, SortDirection.Desc, CertificateSortField.Id) => o.ThenByDescending(c => c.Id),
                (var o, SortDirection.Asc, CertificateSortField.UserId) => o.ThenBy(c => c.UserId),
                (var o, SortDirection.Desc, CertificateSortField.UserId) => o.ThenByDescending(c => c.UserId),
                (var o, SortDirection.Asc, CertificateSortField.CourseId) => o.ThenBy(c => c.CourseId),
                (var o, SortDirection.Desc, CertificateSortField.CourseId) => o.ThenByDescending(c => c.CourseId),
                (var o, SortDirection.Asc, CertificateSortField.IssueDate) => o.ThenBy(c => c.IssueDate),
                (var o, SortDirection.Desc, CertificateSortField.IssueDate) => o.ThenByDescending(c => c.IssueDate),
                _ => ordered ?? query.OrderBy(c => c.Id)
            };
        }
        return ordered ?? query;
    }
}