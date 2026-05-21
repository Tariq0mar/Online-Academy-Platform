using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface ICertificateRepository : IQueryableRepository<Certificate, CertificateQuery>
{
    Task<Certificate?> GetByUserAndCourseAsync(int userId, int courseId);

    Task<bool> ExistsByUserAndCourseAsync(int userId, int courseId);

    Task<IEnumerable<Certificate>> GetByUserIdAsync(int userId);

    Task<IEnumerable<Certificate>> GetByCourseIdAsync(int courseId);
}
