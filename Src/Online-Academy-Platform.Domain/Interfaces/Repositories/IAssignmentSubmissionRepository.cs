using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface IAssignmentSubmissionRepository : IRepository<AssignmentSubmission>
{
    Task<IEnumerable<AssignmentSubmission>> QueryAsync(AssignmentSubmissionQuery query);
}