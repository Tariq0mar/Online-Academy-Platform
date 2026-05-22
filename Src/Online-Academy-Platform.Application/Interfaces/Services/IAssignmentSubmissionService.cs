using Online_Academy_Platform.Application.DTOs.Assignments.Requests;
using Online_Academy_Platform.Application.DTOs.Assignments.Responses;

namespace Online_Academy_Platform.Application.Interfaces.Services;

public interface IAssignmentSubmissionService
{
    Task<AssignmentSubmissionResponse> SubmitAsync(SubmitAssignmentRequest request);

    Task<AssignmentSubmissionResponse> ResubmitAsync(int id, SubmitAssignmentRequest request);

    Task GradeAsync(GradeAssignmentRequest request);

    Task<AssignmentSubmissionResponse> GetByAssignmentAndUserAsync(int assignmentId, int userId);

    Task<IEnumerable<AssignmentSubmissionResponse>> GetByAssignmentIdAsync(int assignmentId);

    Task<IEnumerable<AssignmentSubmissionResponse>> GetByUserIdAsync(int userId);

    Task<AssignmentSubmissionResponse> GetByIdAsync(int id);

    Task<IEnumerable<AssignmentSubmissionResponse>> GetAllAsync();

    Task DeleteAsync(int id);
}