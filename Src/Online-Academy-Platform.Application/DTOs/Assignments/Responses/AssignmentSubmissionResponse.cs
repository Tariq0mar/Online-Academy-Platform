using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Assignments.Responses;

public sealed record AssignmentSubmissionResponse(
    int Id,
    int AssignmentId,
    int UserId,
    string SubmissionFile,
    DateTime SubmissionDate,
    int? Grade,
    string? Feedback,
    SubmissionStatus Status);