using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Entities;

public class Course
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public decimal Price { get; set; }

    public Currency Currency { get; set; } = Currency.USD;

    public int DurationHours { get; set; }

    public CourseLevel Level { get; set; }

    public CourseStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    /// <summary>Many instructors per course via join rows; see <see cref="CourseInstructor"/>.</summary>
    public ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();

    public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
}
