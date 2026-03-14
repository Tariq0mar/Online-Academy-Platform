using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface ICourseInstructorRepository : IRepository<CourseInstructor>
{
    Task<IEnumerable<CourseInstructor>> QueryAsync(CourseInstructorQuery query);
}