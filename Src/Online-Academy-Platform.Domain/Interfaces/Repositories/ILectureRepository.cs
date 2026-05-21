using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface ILectureRepository : IQueryableRepository<Lecture, LectureQuery>
{
    Task<IEnumerable<Lecture>> GetByCourseIdAsync(int courseId);

    Task<bool> ExistsByCourseAndTitleAsync(int courseId, string title);

    Task<bool> ExistsByCourseAndTitleAsync(int courseId, string title, int excludeLectureId);
}
