using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Domain.Queries;
using Online_Academy_Platform.Infrastructure.Persistence;
using Online_Academy_Platform.Infrastructure.Repositories.Common;
using Online_Academy_Platform.Infrastructure.Repositories.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories;

public class LectureRepository(ApplicationDbContext context)
    : QueryableRepository<Lecture, LectureQuery>(context), ILectureRepository
{
    protected override IQueryable<Lecture> ApplyQuery(IQueryable<Lecture> query, LectureQuery queryParams) =>
        LectureQueryApplicator.Apply(query, queryParams);

    protected override int GetPage(LectureQuery query) => QueryHelper.GetPage(query.Pagination);

    protected override int GetPageSize(LectureQuery query) => QueryHelper.GetPageSize(query.Pagination);

    public async Task<IEnumerable<Lecture>> GetByCourseIdAsync(int courseId) =>
        await DbSet.Where(l => l.CourseId == courseId).ToListAsync();

    public async Task<bool> ExistsByCourseAndTitleAsync(int courseId, string title) =>
        await DbSet.AnyAsync(l => l.CourseId == courseId && l.Title == title);

    public async Task<bool> ExistsByCourseAndTitleAsync(int courseId, string title, int excludeLectureId) =>
        await DbSet.AnyAsync(l => l.CourseId == courseId && l.Title == title && l.Id != excludeLectureId);
}
