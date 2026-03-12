using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface ICourseService: IService<Course>
{
    Task<Course> QueryAsync(CourseQuery query);
}