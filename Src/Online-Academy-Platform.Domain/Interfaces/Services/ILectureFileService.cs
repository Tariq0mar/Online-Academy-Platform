using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface ILectureFileService : ISearchableService<LectureFile, LectureFileQuery>
{
    Task<IEnumerable<LectureFile>> GetByLectureIdAsync(int lectureId);
}
