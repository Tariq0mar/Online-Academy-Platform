namespace Online_Academy_Platform.Application.DTOs.Assignments.Requests;

public sealed record GradeAssignmentRequest(int SubmissionId, int Grade, string? Feedback);