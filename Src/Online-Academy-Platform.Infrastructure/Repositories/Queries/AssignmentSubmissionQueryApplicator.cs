using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories.Queries;

internal static class AssignmentSubmissionQueryApplicator
{
    public static IQueryable<AssignmentSubmission> Apply(IQueryable<AssignmentSubmission> query, AssignmentSubmissionQuery parameters)
    {
        if (parameters.AssignmentId.HasValue)
            query = query.Where(s => s.AssignmentId == parameters.AssignmentId.Value);
        if (parameters.UserId.HasValue)
            query = query.Where(s => s.UserId == parameters.UserId.Value);
        if (parameters.Status.HasValue)
            query = query.Where(s => s.Status == parameters.Status.Value);
        if (parameters.MinGrade.HasValue)
            query = query.Where(s => s.Grade >= parameters.MinGrade.Value);
        if (parameters.MaxGrade.HasValue)
            query = query.Where(s => s.Grade <= parameters.MaxGrade.Value);
        if (parameters.SubmittedAfter.HasValue)
            query = query.Where(s => s.SubmissionDate >= parameters.SubmittedAfter.Value);
        if (parameters.SubmittedBefore.HasValue)
            query = query.Where(s => s.SubmissionDate <= parameters.SubmittedBefore.Value);

        if (parameters.Sorts.Count == 0)
            return query.OrderBy(s => s.Id);

        IOrderedQueryable<AssignmentSubmission>? ordered = null;
        foreach (var sort in parameters.Sorts)
        {
            ordered = (ordered, sort.Direction, sort.PropertyName) switch
            {
                (null, SortDirection.Asc, AssignmentSubmissionSortField.Id) => query.OrderBy(s => s.Id),
                (null, SortDirection.Desc, AssignmentSubmissionSortField.Id) => query.OrderByDescending(s => s.Id),
                (null, SortDirection.Asc, AssignmentSubmissionSortField.AssignmentId) => query.OrderBy(s => s.AssignmentId),
                (null, SortDirection.Desc, AssignmentSubmissionSortField.AssignmentId) => query.OrderByDescending(s => s.AssignmentId),
                (null, SortDirection.Asc, AssignmentSubmissionSortField.UserId) => query.OrderBy(s => s.UserId),
                (null, SortDirection.Desc, AssignmentSubmissionSortField.UserId) => query.OrderByDescending(s => s.UserId),
                (null, SortDirection.Asc, AssignmentSubmissionSortField.Grade) => query.OrderBy(s => s.Grade),
                (null, SortDirection.Desc, AssignmentSubmissionSortField.Grade) => query.OrderByDescending(s => s.Grade),
                (null, SortDirection.Asc, AssignmentSubmissionSortField.SubmissionDate) => query.OrderBy(s => s.SubmissionDate),
                (null, SortDirection.Desc, AssignmentSubmissionSortField.SubmissionDate) => query.OrderByDescending(s => s.SubmissionDate),
                (null, SortDirection.Asc, AssignmentSubmissionSortField.Status) => query.OrderBy(s => s.Status),
                (null, SortDirection.Desc, AssignmentSubmissionSortField.Status) => query.OrderByDescending(s => s.Status),
                (var o, SortDirection.Asc, AssignmentSubmissionSortField.Id) => o.ThenBy(s => s.Id),
                (var o, SortDirection.Desc, AssignmentSubmissionSortField.Id) => o.ThenByDescending(s => s.Id),
                (var o, SortDirection.Asc, AssignmentSubmissionSortField.AssignmentId) => o.ThenBy(s => s.AssignmentId),
                (var o, SortDirection.Desc, AssignmentSubmissionSortField.AssignmentId) => o.ThenByDescending(s => s.AssignmentId),
                (var o, SortDirection.Asc, AssignmentSubmissionSortField.UserId) => o.ThenBy(s => s.UserId),
                (var o, SortDirection.Desc, AssignmentSubmissionSortField.UserId) => o.ThenByDescending(s => s.UserId),
                (var o, SortDirection.Asc, AssignmentSubmissionSortField.Grade) => o.ThenBy(s => s.Grade),
                (var o, SortDirection.Desc, AssignmentSubmissionSortField.Grade) => o.ThenByDescending(s => s.Grade),
                (var o, SortDirection.Asc, AssignmentSubmissionSortField.SubmissionDate) => o.ThenBy(s => s.SubmissionDate),
                (var o, SortDirection.Desc, AssignmentSubmissionSortField.SubmissionDate) => o.ThenByDescending(s => s.SubmissionDate),
                (var o, SortDirection.Asc, AssignmentSubmissionSortField.Status) => o.ThenBy(s => s.Status),
                (var o, SortDirection.Desc, AssignmentSubmissionSortField.Status) => o.ThenByDescending(s => s.Status),
                _ => ordered ?? query.OrderBy(s => s.Id)
            };
        }
        return ordered ?? query;
    }
}