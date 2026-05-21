namespace Online_Academy_Platform.Domain.Entities;

public class CourseInstructor
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int InstructorId { get; set; }

    public DateTime AssignedAt { get; set; }

    public bool IsPrimary { get; set; }

    public User Instructor { get; set; } = null!;

    public Course Course { get; set; } = null!;
}
