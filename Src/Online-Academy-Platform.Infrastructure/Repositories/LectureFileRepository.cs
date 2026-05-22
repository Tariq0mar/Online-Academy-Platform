using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Domain.Queries;
using Online_Academy_Platform.Infrastructure.Persistence;
using Online_Academy_Platform.Infrastructure.Repositories.Common;
using Online_Academy_Platform.Infrastructure.Repositories.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories;

public class LectureFileRepository(ApplicationDbContext context)
    : QueryableRepository<LectureFile, LectureFileQuery>(context), ILectureFileRepository
{
    protected override IQueryable<LectureFile> ApplyQuery(IQueryable<LectureFile> query, LectureFileQuery queryParams) =>
        LectureFileQueryApplicator.Apply(query, queryParams);

    protected override int GetPage(LectureFileQuery query) => QueryHelper.GetPage(query.Pagination);

    protected override int GetPageSize(LectureFileQuery query) => QueryHelper.GetPageSize(query.Pagination);

    public async Task<IEnumerable<LectureFile>> GetByLectureIdAsync(int lectureId) =>
        await DbSet.Where(f => f.LectureId == lectureId).ToListAsync();

    public async Task DeleteByLectureIdAsync(int lectureId)
    {
        await DbSet.Where(f => f.LectureId == lectureId).ExecuteDeleteAsync();
    }
}
