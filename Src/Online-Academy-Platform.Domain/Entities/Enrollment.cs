using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Entities;

public class Enrollment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CourseId { get; set; }

    public EnrollmentStatus Status { get; set; } = EnrollmentStatus.PendingPayment;

    public DateTime EnrolledAt { get; set; }

    public User User { get; set; } = null!;

    public Course Course { get; set; } = null!;

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
