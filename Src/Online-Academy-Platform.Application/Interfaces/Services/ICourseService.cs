using Online_Academy_Platform.Application.DTOs.Courses.Requests;
using Online_Academy_Platform.Application.DTOs.Courses.Responses;

namespace Online_Academy_Platform.Application.Interfaces.Services;

public interface ICourseService
{
    Task<IEnumerable<CourseResponse>> GetByInstructorIdAsync(int instructorId);

    Task<CourseResponse> AddAsync(CreateCourseRequest request);

    Task<CourseResponse> GetByIdAsync(int id);

    Task<IEnumerable<CourseResponse>> GetAllAsync();

    Task<CourseResponse> UpdateAsync(int id, UpdateCourseRequest request);

    Task DeleteAsync(int id);
}