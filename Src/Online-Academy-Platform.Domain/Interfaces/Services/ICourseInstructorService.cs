using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface ICourseInstructorService : ISearchableService<CourseInstructor, CourseInstructorQuery>
{
    Task<CourseInstructor> AssignAsync(int courseId, int instructorId, bool isPrimary = false);

    Task RemoveAsync(int courseId, int instructorId);

    Task SetPrimaryInstructorAsync(int courseId, int instructorId);

    Task<IEnumerable<CourseInstructor>> GetByCourseIdAsync(int courseId);
}
