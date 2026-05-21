using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface IAttendanceService : ISearchableService<Attendance, AttendanceQuery>
{
    Task<Attendance> RecordAsync(int lectureId, int userId, AttendanceStatus status);

    Task<Attendance?> GetByLectureAndUserAsync(int lectureId, int userId);
}
