using Online_Academy_Platform.Application.DTOs.LecturesFiles.Requests;
using Online_Academy_Platform.Application.DTOs.LecturesFiles.Responses;

namespace Online_Academy_Platform.Application.Interfaces.Services;

public interface ILectureFileService
{
    Task<IEnumerable<LectureFileResponse>> GetByLectureIdAsync(int lectureId);

    Task<string> GetDownloadUrlAsync(int fileId);

    Task<LectureFileResponse> AddAsync(CreateLectureFileRequest request);

    Task<LectureFileResponse> GetByIdAsync(int id);

    Task<IEnumerable<LectureFileResponse>> GetAllAsync();

    Task<LectureFileResponse> UpdateAsync(int id, UpdateLectureFileRequest request);

    Task DeleteAsync(int id);
}