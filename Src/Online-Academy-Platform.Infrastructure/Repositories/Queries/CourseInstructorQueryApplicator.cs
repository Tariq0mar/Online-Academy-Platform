using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories.Queries;

internal static class CourseInstructorQueryApplicator
{
    public static IQueryable<CourseInstructor> Apply(IQueryable<CourseInstructor> query, CourseInstructorQuery parameters)
    {
        if (parameters.CourseId.HasValue)
            query = query.Where(ci => ci.CourseId == parameters.CourseId.Value);
        if (parameters.InstructorId.HasValue)
            query = query.Where(ci => ci.InstructorId == parameters.InstructorId.Value);
        if (parameters.IsPrimary.HasValue)
            query = query.Where(ci => ci.IsPrimary == parameters.IsPrimary.Value);

        return ApplySort(query, parameters.Sorts);
    }

    private static IQueryable<CourseInstructor> ApplySort(IQueryable<CourseInstructor> query, List<SortCriteria<CourseInstructorSortField>> sorts)
    {
        if (sorts.Count == 0) return query.OrderBy(ci => ci.Id);
        IOrderedQueryable<CourseInstructor>? ordered = null;
        foreach (var sort in sorts)
        {
            ordered = (ordered, sort.Direction, sort.PropertyName) switch
            {
                (null, SortDirection.Asc, CourseInstructorSortField.Id) => query.OrderBy(ci => ci.Id),
                (null, SortDirection.Desc, CourseInstructorSortField.Id) => query.OrderByDescending(ci => ci.Id),
                (null, SortDirection.Asc, CourseInstructorSortField.CourseId) => query.OrderBy(ci => ci.CourseId),
                (null, SortDirection.Desc, CourseInstructorSortField.CourseId) => query.OrderByDescending(ci => ci.CourseId),
                (null, SortDirection.Asc, CourseInstructorSortField.InstructorId) => query.OrderBy(ci => ci.InstructorId),
                (null, SortDirection.Desc, CourseInstructorSortField.InstructorId) => query.OrderByDescending(ci => ci.InstructorId),
                (null, SortDirection.Asc, CourseInstructorSortField.AssignedAt) => query.OrderBy(ci => ci.AssignedAt),
                (null, SortDirection.Desc, CourseInstructorSortField.AssignedAt) => query.OrderByDescending(ci => ci.AssignedAt),
                (null, SortDirection.Asc, CourseInstructorSortField.IsPrimary) => query.OrderBy(ci => ci.IsPrimary),
                (null, SortDirection.Desc, CourseInstructorSortField.IsPrimary) => query.OrderByDescending(ci => ci.IsPrimary),
                (var o, SortDirection.Asc, CourseInstructorSortField.Id) => o.ThenBy(ci => ci.Id),
                (var o, SortDirection.Desc, CourseInstructorSortField.Id) => o.ThenByDescending(ci => ci.Id),
                (var o, SortDirection.Asc, CourseInstructorSortField.CourseId) => o.ThenBy(ci => ci.CourseId),
                (var o, SortDirection.Desc, CourseInstructorSortField.CourseId) => o.ThenByDescending(ci => ci.CourseId),
                (var o, SortDirection.Asc, CourseInstructorSortField.InstructorId) => o.ThenBy(ci => ci.InstructorId),
                (var o, SortDirection.Desc, CourseInstructorSortField.InstructorId) => o.ThenByDescending(ci => ci.InstructorId),
                (var o, SortDirection.Asc, CourseInstructorSortField.AssignedAt) => o.ThenBy(ci => ci.AssignedAt),
                (var o, SortDirection.Desc, CourseInstructorSortField.AssignedAt) => o.ThenByDescending(ci => ci.AssignedAt),
                (var o, SortDirection.Asc, CourseInstructorSortField.IsPrimary) => o.ThenBy(ci => ci.IsPrimary),
                (var o, SortDirection.Desc, CourseInstructorSortField.IsPrimary) => o.ThenByDescending(ci => ci.IsPrimary),
                _ => ordered ?? query.OrderBy(ci => ci.Id)
            };
        }
        return ordered ?? query;
    }
}