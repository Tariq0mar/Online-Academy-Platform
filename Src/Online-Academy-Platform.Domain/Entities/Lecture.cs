namespace Online_Academy_Platform.Domain.Entities;

public class Lecture
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public DateTime LectureDate { get; set; }

    public int DurationMinutes { get; set; }

    public Course Course { get; set; } = null!;

    public ICollection<LectureFile> Files { get; set; } = new List<LectureFile>();

    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
