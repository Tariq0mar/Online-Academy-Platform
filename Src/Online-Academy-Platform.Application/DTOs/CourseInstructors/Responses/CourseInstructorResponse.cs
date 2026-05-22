using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.CourseInstructors.Responses;

public sealed record CourseInstructorResponse(
    int Id,
    int CourseId,
    int InstructorId,
    DateTime AssignedAt,
    bool IsPrimary);