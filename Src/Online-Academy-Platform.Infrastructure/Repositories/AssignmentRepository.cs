using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Domain.Queries;
using Online_Academy_Platform.Infrastructure.Persistence;
using Online_Academy_Platform.Infrastructure.Repositories.Common;
using Online_Academy_Platform.Infrastructure.Repositories.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories;

public class AssignmentRepository(ApplicationDbContext context)
    : QueryableRepository<Assignment, AssignmentQuery>(context), IAssignmentRepository
{
    protected override IQueryable<Assignment> ApplyQuery(IQueryable<Assignment> query, AssignmentQuery queryParams) =>
        AssignmentQueryApplicator.Apply(query, queryParams);

    protected override int GetPage(AssignmentQuery query) => QueryHelper.GetPage(query.Pagination);

    protected override int GetPageSize(AssignmentQuery query) => QueryHelper.GetPageSize(query.Pagination);

    public async Task<IEnumerable<Assignment>> GetByCourseIdAsync(int courseId) =>
        await DbSet.Where(a => a.CourseId == courseId).ToListAsync();

    public async Task<bool> ExistsByCourseAndTitleAsync(int courseId, string title) =>
        await DbSet.AnyAsync(a => a.CourseId == courseId && a.Title == title);

    public async Task<bool> ExistsByCourseAndTitleAsync(int courseId, string title, int excludeAssignmentId) =>
        await DbSet.AnyAsync(a => a.CourseId == courseId && a.Title == title && a.Id != excludeAssignmentId);
}
