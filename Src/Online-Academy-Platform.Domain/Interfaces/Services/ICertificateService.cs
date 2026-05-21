using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface ICertificateService : ISearchableService<Certificate, CertificateQuery>
{
    Task<Certificate> IssueAsync(int userId, int courseId, string certificateUrl);

    Task<bool> HasCertificateAsync(int userId, int courseId);

    Task<Certificate?> GetByUserAndCourseAsync(int userId, int courseId);
}
