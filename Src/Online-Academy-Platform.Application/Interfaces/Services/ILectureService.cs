using Online_Academy_Platform.Application.DTOs.Lectures.Requests;
using Online_Academy_Platform.Application.DTOs.Lectures.Responses;

namespace Online_Academy_Platform.Application.Interfaces.Services;

public interface ILectureService
{
    Task<IEnumerable<LectureResponse>> GetByCourseIdAsync(int courseId);

    Task ReorderAsync(int courseId, ReorderLecturesRequest request);

    Task<LectureResponse> AddAsync(CreateLectureRequest request);

    Task<LectureResponse> GetByIdAsync(int id);

    Task<IEnumerable<LectureResponse>> GetAllAsync();

    Task<LectureResponse> UpdateAsync(int id, UpdateLectureRequest request);

    Task DeleteAsync(int id);
}