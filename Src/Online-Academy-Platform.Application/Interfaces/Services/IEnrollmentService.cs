using Online_Academy_Platform.Application.DTOs.Enrollments.Requests;
using Online_Academy_Platform.Application.DTOs.Enrollments.Responses;

namespace Online_Academy_Platform.Application.Interfaces.Services;

public interface IEnrollmentService
{
    Task<EnrollmentResponse> EnrollAsync(EnrollRequest request);

    Task<EnrollmentResponse> GetByUserAndCourseAsync(int userId, int courseId);

    Task<bool> IsEnrolledAsync(int userId, int courseId);

    Task CancelAsync(int enrollmentId);

    Task<IEnumerable<EnrollmentResponse>> GetByUserIdAsync(int userId);

    Task<IEnumerable<EnrollmentResponse>> GetByCourseIdAsync(int courseId);

    Task<EnrollmentResponse> GetByIdAsync(int id);

    Task<IEnumerable<EnrollmentResponse>> GetAllAsync();

    Task DeleteAsync(int id);
}