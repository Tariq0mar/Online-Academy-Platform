using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Entities;

public class User
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public required string Phone { get; set; }

    public string? ProfilePicture { get; set; }

    public bool Active { get; set; }

    public UserRole Role { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<CourseInstructor> CourseInstructorAssignments { get; set; } = new List<CourseInstructor>();

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; } = new List<AssignmentSubmission>();

    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
}
