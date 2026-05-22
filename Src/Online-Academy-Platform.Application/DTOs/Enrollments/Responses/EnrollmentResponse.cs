using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Enrollments.Responses;

public sealed record EnrollmentResponse(
    int Id,
    int UserId,
    int CourseId,
    EnrollmentStatus Status,
    DateTime EnrolledAt);