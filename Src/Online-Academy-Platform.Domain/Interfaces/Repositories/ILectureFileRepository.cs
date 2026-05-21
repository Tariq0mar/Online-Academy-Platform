using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface ILectureFileRepository : IQueryableRepository<LectureFile, LectureFileQuery>
{
    Task<IEnumerable<LectureFile>> GetByLectureIdAsync(int lectureId);

    Task DeleteByLectureIdAsync(int lectureId);
}
