using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Assignments.Responses;

public sealed record AssignmentResponse(
    int Id,
    int CourseId,
    string Title,
    string Description,
    int MaxGrade,
    DateTime Deadline,
    DateTime CreatedAt);