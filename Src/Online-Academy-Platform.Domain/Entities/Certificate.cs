namespace Online_Academy_Platform.Domain.Entities;

public class Certificate
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CourseId { get; set; }

    public DateTime IssueDate { get; set; }

    public required string CertificateUrl { get; set; }

    public User User { get; set; } = null!;

    public Course Course { get; set; } = null!;
}
