using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface ICertificateRepository : IRepository<Certificate>
{
    Task<IEnumerable<Certificate>> QueryAsync(CertificateQuery query);
}