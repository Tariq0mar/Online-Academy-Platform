using Online_Academy_Platform.Application.DTOs.Attendances.Requests;
using Online_Academy_Platform.Application.DTOs.Attendances.Responses;

namespace Online_Academy_Platform.Application.Interfaces.Services;

public interface IAttendanceService
{
    Task<AttendanceResponse> RecordAsync(RecordAttendanceRequest request);

    Task<IEnumerable<AttendanceResponse>> BulkRecordAsync(IEnumerable<RecordAttendanceRequest> records);

    Task<AttendanceResponse> GetByLectureAndUserAsync(int lectureId, int userId);

    Task<IEnumerable<AttendanceResponse>> GetByLectureIdAsync(int lectureId);

    Task<IEnumerable<AttendanceResponse>> GetByUserIdAsync(int userId);

    Task<AttendanceResponse> GetByIdAsync(int id);

    Task<IEnumerable<AttendanceResponse>> GetAllAsync();

    Task DeleteAsync(int id);
}