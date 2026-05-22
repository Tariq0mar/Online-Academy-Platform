namespace Online_Academy_Platform.Application.DTOs.Assignments.Requests;

public sealed record UpdateAssignmentRequest(
    int CourseId,
    string Title,
    string Description,
    int MaxGrade,
    DateTime Deadline);