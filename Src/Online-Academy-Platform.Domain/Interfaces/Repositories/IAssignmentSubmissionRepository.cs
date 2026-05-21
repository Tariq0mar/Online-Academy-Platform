using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface IAssignmentSubmissionRepository : IQueryableRepository<AssignmentSubmission, AssignmentSubmissionQuery>
{
    Task<AssignmentSubmission?> GetByAssignmentAndUserAsync(int assignmentId, int userId);

    Task<bool> ExistsByAssignmentAndUserAsync(int assignmentId, int userId);

    Task<IEnumerable<AssignmentSubmission>> GetByAssignmentIdAsync(int assignmentId);

    Task<IEnumerable<AssignmentSubmission>> GetByUserIdAsync(int userId);

    Task<bool> UpdateGradeAsync(int submissionId, int grade, string? feedback, SubmissionStatus status);
}
