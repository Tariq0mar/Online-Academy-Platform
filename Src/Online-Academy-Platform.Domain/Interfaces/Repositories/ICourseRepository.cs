using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface ICourseRepository : IQueryableRepository<Course, CourseQuery>
{
    Task<IEnumerable<Course>> GetByStatusAsync(CourseStatus status);

    Task<bool> ExistsAsync(int id, CourseStatus status);
}
