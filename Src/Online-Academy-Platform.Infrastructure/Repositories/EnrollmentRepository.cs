using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Domain.Queries;
using Online_Academy_Platform.Infrastructure.Persistence;
using Online_Academy_Platform.Infrastructure.Repositories.Common;
using Online_Academy_Platform.Infrastructure.Repositories.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories;

public class EnrollmentRepository(ApplicationDbContext context)
    : QueryableRepository<Enrollment, EnrollmentQuery>(context), IEnrollmentRepository
{
    protected override IQueryable<Enrollment> ApplyQuery(IQueryable<Enrollment> query, EnrollmentQuery queryParams) =>
        EnrollmentQueryApplicator.Apply(query, queryParams);

    protected override int GetPage(EnrollmentQuery query) => QueryHelper.GetPage(query.Pagination);

    protected override int GetPageSize(EnrollmentQuery query) => QueryHelper.GetPageSize(query.Pagination);

    public async Task<Enrollment?> GetByUserAndCourseAsync(int userId, int courseId) =>
        await DbSet.FirstOrDefaultAsync(e => e.UserId == userId && e.CourseId == courseId);

    public async Task<bool> ExistsByUserAndCourseAsync(int userId, int courseId) =>
        await DbSet.AnyAsync(e => e.UserId == userId && e.CourseId == courseId);

    public async Task<bool> ExistsByUserAndCourseAsync(int userId, int courseId, EnrollmentStatus status) =>
        await DbSet.AnyAsync(e => e.UserId == userId && e.CourseId == courseId && e.Status == status);

    public async Task<IEnumerable<Enrollment>> GetByUserIdAsync(int userId) =>
        await DbSet.Where(e => e.UserId == userId).ToListAsync();

    public async Task<IEnumerable<Enrollment>> GetByCourseIdAsync(int courseId) =>
        await DbSet.Where(e => e.CourseId == courseId).ToListAsync();
}
