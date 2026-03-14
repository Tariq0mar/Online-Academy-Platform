using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface ICourseRepository : IRepository<Course>
{
    Task<IEnumerable<Course>> QueryAsync(CourseQuery query);
}