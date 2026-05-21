using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Domain.Queries;
using Online_Academy_Platform.Infrastructure.Persistence;
using Online_Academy_Platform.Infrastructure.Repositories.Common;
using Online_Academy_Platform.Infrastructure.Repositories.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories;

public class CourseRepository(ApplicationDbContext context)
    : QueryableRepository<Course, CourseQuery>(context), ICourseRepository
{
    protected override IQueryable<Course> ApplyQuery(IQueryable<Course> query, CourseQuery queryParams) =>
        CourseQueryApplicator.Apply(query, queryParams);

    protected override int GetPage(CourseQuery query) => QueryHelper.GetPage(query.Pagination);

    protected override int GetPageSize(CourseQuery query) => QueryHelper.GetPageSize(query.Pagination);

    public async Task<IEnumerable<Course>> GetByStatusAsync(CourseStatus status) =>
        await DbSet.Where(c => c.Status == status).ToListAsync();

    public async Task<bool> ExistsAsync(int id, CourseStatus status) =>
        await DbSet.AnyAsync(c => c.Id == id && c.Status == status);
}
