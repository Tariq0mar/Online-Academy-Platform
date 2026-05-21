using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface IAssignmentSubmissionRepository : IQueryableRepository<AssignmentSubmission, AssignmentSubmissionQuery>
{
    Task<AssignmentSubmission?> GetByAssignmentAndUserAsync(int assignmentId, int userId);

    Task<bool> ExistsByAssignmentAndUserAsync(int assignmentId, int userId);
}
