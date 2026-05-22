using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Enrollments.Requests;

public sealed record UpdateEnrollmentStatusRequest(
    EnrollmentStatus Status);