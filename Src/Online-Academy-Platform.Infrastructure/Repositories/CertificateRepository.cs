using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Domain.Queries;
using Online_Academy_Platform.Infrastructure.Persistence;
using Online_Academy_Platform.Infrastructure.Repositories.Common;
using Online_Academy_Platform.Infrastructure.Repositories.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories;

public class CertificateRepository(ApplicationDbContext context)
    : QueryableRepository<Certificate, CertificateQuery>(context), ICertificateRepository
{
    protected override IQueryable<Certificate> ApplyQuery(IQueryable<Certificate> query, CertificateQuery queryParams) =>
        CertificateQueryApplicator.Apply(query, queryParams);

    protected override int GetPage(CertificateQuery query) => QueryHelper.GetPage(query.Pagination);

    protected override int GetPageSize(CertificateQuery query) => QueryHelper.GetPageSize(query.Pagination);

    public async Task<Certificate?> GetByUserAndCourseAsync(int userId, int courseId) =>
        await DbSet.FirstOrDefaultAsync(c => c.UserId == userId && c.CourseId == courseId);

    public async Task<bool> ExistsByUserAndCourseAsync(int userId, int courseId) =>
        await DbSet.AnyAsync(c => c.UserId == userId && c.CourseId == courseId);

    public async Task<IEnumerable<Certificate>> GetByUserIdAsync(int userId) =>
        await DbSet.Where(c => c.UserId == userId).ToListAsync();

    public async Task<IEnumerable<Certificate>> GetByCourseIdAsync(int courseId) =>
        await DbSet.Where(c => c.CourseId == courseId).ToListAsync();
}
