using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Domain.Queries;
using Online_Academy_Platform.Infrastructure.Persistence;
using Online_Academy_Platform.Infrastructure.Repositories.Common;
using Online_Academy_Platform.Infrastructure.Repositories.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories;

public class AttendanceRepository(ApplicationDbContext context)
    : QueryableRepository<Attendance, AttendanceQuery>(context), IAttendanceRepository
{
    protected override IQueryable<Attendance> ApplyQuery(IQueryable<Attendance> query, AttendanceQuery queryParams) =>
        AttendanceQueryApplicator.Apply(query, queryParams);

    protected override int GetPage(AttendanceQuery query) => QueryHelper.GetPage(query.Pagination);

    protected override int GetPageSize(AttendanceQuery query) => QueryHelper.GetPageSize(query.Pagination);

    public async Task<Attendance?> GetByLectureAndUserAsync(int lectureId, int userId) =>
        await DbSet.FirstOrDefaultAsync(a => a.LectureId == lectureId && a.UserId == userId);

    public async Task<bool> ExistsByLectureAndUserAsync(int lectureId, int userId) =>
        await DbSet.AnyAsync(a => a.LectureId == lectureId && a.UserId == userId);

    public async Task<IEnumerable<Attendance>> GetByLectureIdAsync(int lectureId) =>
        await DbSet.Where(a => a.LectureId == lectureId).ToListAsync();

    public async Task<IEnumerable<Attendance>> GetByUserIdAsync(int userId) =>
        await DbSet.Where(a => a.UserId == userId).ToListAsync();
}
