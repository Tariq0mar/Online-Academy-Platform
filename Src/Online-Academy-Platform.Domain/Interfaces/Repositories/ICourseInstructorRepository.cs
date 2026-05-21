using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface ICourseInstructorRepository : IQueryableRepository<CourseInstructor, CourseInstructorQuery>
{
    Task<IEnumerable<CourseInstructor>> GetByCourseIdAsync(int courseId);

    Task<IEnumerable<CourseInstructor>> GetByInstructorIdAsync(int instructorId);

    Task<CourseInstructor?> GetByCourseAndInstructorAsync(int courseId, int instructorId);

    Task<CourseInstructor?> GetPrimaryByCourseIdAsync(int courseId);

    Task<bool> ExistsByCourseAndInstructorAsync(int courseId, int instructorId);

    Task<bool> HasPrimaryInstructorAsync(int courseId);

    Task ClearPrimaryForCourseAsync(int courseId);

    Task DeleteByCourseAndInstructorAsync(int courseId, int instructorId);
}
