namespace Online_Academy_Platform.Application.DTOs.CourseInstructors.Requests;

public sealed record RemoveInstructorRequest(
    int CourseId,
    int InstructorId);