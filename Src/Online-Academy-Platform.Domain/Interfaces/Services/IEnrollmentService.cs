using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface IEnrollmentService : ISearchableService<Enrollment, EnrollmentQuery>
{
    Task<Enrollment> EnrollAsync(int userId, int courseId);

    Task<Enrollment?> GetByUserAndCourseAsync(int userId, int courseId);

    Task<bool> IsEnrolledAsync(int userId, int courseId);

    Task UpdateStatusAsync(int enrollmentId, EnrollmentStatus status);

    Task ActivateAsync(int enrollmentId);

    Task CancelAsync(int enrollmentId);
}
