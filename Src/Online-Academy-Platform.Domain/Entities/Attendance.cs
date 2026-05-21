using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Entities;

public class Attendance
{
    public int Id { get; set; }

    public int LectureId { get; set; }

    public int UserId { get; set; }

    public AttendanceStatus Status { get; set; } = AttendanceStatus.Present;

    public Lecture Lecture { get; set; } = null!;

    public User User { get; set; } = null!;
}
