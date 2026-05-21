using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface ICourseService : ISearchableService<Course, CourseQuery>
{
    Task UpdateStatusAsync(int courseId, CourseStatus status);
}
