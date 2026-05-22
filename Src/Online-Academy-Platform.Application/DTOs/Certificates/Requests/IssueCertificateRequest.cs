namespace Online_Academy_Platform.Application.DTOs.Certificates.Requests;

public sealed record IssueCertificateRequest(
    int UserId,
    int CourseId,
    string CertificateUrl);