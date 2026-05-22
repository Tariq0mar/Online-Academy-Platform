using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Certificates.Responses;

public sealed record CertificateResponse(
    int Id,
    int UserId,
    int CourseId,
    DateTime IssueDate,
    string CertificateUrl);