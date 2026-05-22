using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Domain.Queries;
using Online_Academy_Platform.Infrastructure.Persistence;
using Online_Academy_Platform.Infrastructure.Repositories.Common;
using Online_Academy_Platform.Infrastructure.Repositories.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories;

public class CourseInstructorRepository(ApplicationDbContext context)
    : QueryableRepository<CourseInstructor, CourseInstructorQuery>(context), ICourseInstructorRepository
{
    protected override IQueryable<CourseInstructor> ApplyQuery(IQueryable<CourseInstructor> query, CourseInstructorQuery queryParams) =>
        CourseInstructorQueryApplicator.Apply(query, queryParams);

    protected override int GetPage(CourseInstructorQuery query) => QueryHelper.GetPage(query.Pagination);

    protected override int GetPageSize(CourseInstructorQuery query) => QueryHelper.GetPageSize(query.Pagination);

    public async Task<IEnumerable<CourseInstructor>> GetByCourseIdAsync(int courseId) =>
        await DbSet.Where(ci => ci.CourseId == courseId).ToListAsync();

    public async Task<IEnumerable<CourseInstructor>> GetByInstructorIdAsync(int instructorId) =>
        await DbSet.Where(ci => ci.InstructorId == instructorId).ToListAsync();

    public async Task<CourseInstructor?> GetByCourseAndInstructorAsync(int courseId, int instructorId) =>
        await DbSet.FirstOrDefaultAsync(ci => ci.CourseId == courseId && ci.InstructorId == instructorId);

    public async Task<CourseInstructor?> GetPrimaryByCourseIdAsync(int courseId) =>
        await DbSet.FirstOrDefaultAsync(ci => ci.CourseId == courseId && ci.IsPrimary);

    public async Task<bool> ExistsByCourseAndInstructorAsync(int courseId, int instructorId) =>
        await DbSet.AnyAsync(ci => ci.CourseId == courseId && ci.InstructorId == instructorId);

    public async Task<bool> HasPrimaryInstructorAsync(int courseId) =>
        await DbSet.AnyAsync(ci => ci.CourseId == courseId && ci.IsPrimary);

    public async Task ClearPrimaryForCourseAsync(int courseId)
    {
        await DbSet
            .Where(ci => ci.CourseId == courseId && ci.IsPrimary)
            .ExecuteUpdateAsync(s => s.SetProperty(ci => ci.IsPrimary, false));
    }

    public async Task DeleteByCourseAndInstructorAsync(int courseId, int instructorId)
    {
        var entity = await GetByCourseAndInstructorAsync(courseId, instructorId);
        if (entity is null)
        {
            return;
        }

        DbSet.Remove(entity);
        await Context.SaveChangesAsync();
    }
}
