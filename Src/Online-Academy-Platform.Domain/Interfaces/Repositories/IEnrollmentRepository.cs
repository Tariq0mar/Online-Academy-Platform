using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface IEnrollmentRepository : IQueryableRepository<Enrollment, EnrollmentQuery>
{
    Task<Enrollment?> GetByUserAndCourseAsync(int userId, int courseId);

    Task<bool> ExistsByUserAndCourseAsync(int userId, int courseId);
}
