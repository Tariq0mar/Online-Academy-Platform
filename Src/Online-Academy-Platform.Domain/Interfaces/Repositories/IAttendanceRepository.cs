using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface IAttendanceRepository : IQueryableRepository<Attendance, AttendanceQuery>
{
    Task<Attendance?> GetByLectureAndUserAsync(int lectureId, int userId);

    Task<bool> ExistsByLectureAndUserAsync(int lectureId, int userId);
}
