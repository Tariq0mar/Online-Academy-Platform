namespace Online_Academy_Platform.Domain.Entities;

public class Enrollment
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateTime EnrolledAt { get; set; }

    public User Student { get; set; }

    public Course Course { get; set; }
}
