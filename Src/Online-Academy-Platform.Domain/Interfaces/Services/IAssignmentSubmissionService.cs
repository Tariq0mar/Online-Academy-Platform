using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface IAssignmentSubmissionService : ISearchableService<AssignmentSubmission, AssignmentSubmissionQuery>
{
    Task<AssignmentSubmission> SubmitAsync(AssignmentSubmission submission);

    Task GradeAsync(int submissionId, int grade, string? feedback);

    Task<AssignmentSubmission?> GetByAssignmentAndUserAsync(int assignmentId, int userId);
}
