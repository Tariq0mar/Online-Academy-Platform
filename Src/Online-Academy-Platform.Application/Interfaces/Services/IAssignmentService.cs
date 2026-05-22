using Online_Academy_Platform.Application.DTOs.Assignments.Requests;
using Online_Academy_Platform.Application.DTOs.Assignments.Responses;

namespace Online_Academy_Platform.Application.Interfaces.Services;

public interface IAssignmentService
{
    Task<IEnumerable<AssignmentResponse>> GetByCourseIdAsync(int courseId);

    Task<AssignmentResponse> AddAsync(CreateAssignmentRequest request);

    Task<AssignmentResponse> GetByIdAsync(int id);

    Task<IEnumerable<AssignmentResponse>> GetAllAsync();

    Task<AssignmentResponse> UpdateAsync(int id, UpdateAssignmentRequest request);

    Task DeleteAsync(int id);
}