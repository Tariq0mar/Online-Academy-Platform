namespace Online_Academy_Platform.Application.DTOs.CourseInstructors.Requests;

public sealed record AssignInstructorRequest(int CourseId, int InstructorId, bool IsPrimary = false);