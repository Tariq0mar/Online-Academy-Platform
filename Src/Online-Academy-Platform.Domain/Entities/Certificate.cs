namespace Online_Academy_Platform.Domain.Entities;

public class Certificate
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateTime IssueDate { get; set; }

    public string CertificateUrl { get; set; }

    public User Student { get; set; }

    public Course Course { get; set; }
}