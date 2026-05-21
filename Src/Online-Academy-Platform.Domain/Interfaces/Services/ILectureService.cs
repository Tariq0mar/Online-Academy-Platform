using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface ILectureService : ISearchableService<Lecture, LectureQuery>
{
    Task<IEnumerable<Lecture>> GetByCourseIdAsync(int courseId);
}
