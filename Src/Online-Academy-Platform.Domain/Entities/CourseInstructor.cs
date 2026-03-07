namespace Online_Academy_Platform.Domain.Entities;

public class CourseInstructor
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int InstructorId { get; set; }

    public User Instrcutor { get; set; }

    public Course Course { get; set; }
}
