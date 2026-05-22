namespace Online_Academy_Platform.Application.DTOs.Assignments.Requests;

public sealed record SubmitAssignmentRequest(int AssignmentId, int UserId, string SubmissionFile);