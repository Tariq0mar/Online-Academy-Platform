namespace Online_Academy_Platform.Domain.Entities;

public class Assignment
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public int MaxGrade { get; set; }

    public DateTime Deadline { get; set; }

    public DateTime CreatedAt { get; set; }

    public Course Course { get; set; } = null!;

    public ICollection<AssignmentSubmission> Submissions { get; set; } = new List<AssignmentSubmission>();
}
