using Online_Academy_Platform.Application.DTOs.Certificates.Requests;
using Online_Academy_Platform.Application.DTOs.Certificates.Responses;

namespace Online_Academy_Platform.Application.Interfaces.Services;

public interface ICertificateService
{
    Task<CertificateResponse> IssueAsync(IssueCertificateRequest request);

    Task<CertificateResponse> GetByUserAndCourseAsync(int userId, int courseId);

    Task<bool> HasCertificateAsync(int userId, int courseId);

    Task<IEnumerable<CertificateResponse>> GetByUserIdAsync(int userId);

    Task<bool> VerifyAsync(string certificateCode);

    Task RevokeAsync(int certificateId);

    Task<CertificateResponse> GetByIdAsync(int id);

    Task<IEnumerable<CertificateResponse>> GetAllAsync();

    Task DeleteAsync(int id);
}