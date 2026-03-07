namespace Online_Academy_Platform.Domain.Entities;

public class Attendance
{
    public int Id { get; set; }

    public int LectureId { get; set; }

    public int StudentId { get; set; }

    public string Status { get; set; }

    public Lecture Lecture { get; set; }

    public User Student { get; set; }
}
