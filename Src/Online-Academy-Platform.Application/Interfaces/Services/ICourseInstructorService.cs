using Online_Academy_Platform.Application.DTOs.CourseInstructors.Requests;
using Online_Academy_Platform.Application.DTOs.CourseInstructors.Responses;

namespace Online_Academy_Platform.Application.Interfaces.Services;

public interface ICourseInstructorService
{
    Task<CourseInstructorResponse> AssignAsync(AssignInstructorRequest request);

    Task RemoveAsync(RemoveInstructorRequest request);

    Task<CourseInstructorResponse> SetPrimaryInstructorAsync(AssignInstructorRequest request);

    Task<IEnumerable<CourseInstructorResponse>> GetByCourseIdAsync(int courseId);

    Task<IEnumerable<CourseInstructorResponse>> GetByInstructorIdAsync(int instructorId);

    Task<CourseInstructorResponse> GetByIdAsync(int id);

    Task<IEnumerable<CourseInstructorResponse>> GetAllAsync();

    Task DeleteAsync(int id);
}