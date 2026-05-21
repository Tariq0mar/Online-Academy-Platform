using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface IAssignmentRepository : IQueryableRepository<Assignment, AssignmentQuery>
{
    Task<IEnumerable<Assignment>> GetByCourseIdAsync(int courseId);
}
