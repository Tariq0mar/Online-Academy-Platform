using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Entities;

public class AssignmentSubmission
{
    public int Id { get; set; }

    public int AssignmentId { get; set; }

    public int StudentId { get; set; }

    public string SubmissionFile { get; set; }

    public DateTime SubmissionDate { get; set; }

    public int Grade { get; set; }

    public string Feedback { get; set; }

    public SubmissionStatus Status { get; set; }

    public Assignment Assignment { get; set; }

    public User Student { get; set; }
}
