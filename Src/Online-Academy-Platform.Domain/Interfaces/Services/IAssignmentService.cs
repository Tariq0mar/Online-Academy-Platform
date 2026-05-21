using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface IAssignmentService : ISearchableService<Assignment, AssignmentQuery>
{
    Task<IEnumerable<Assignment>> GetByCourseIdAsync(int courseId);
}
