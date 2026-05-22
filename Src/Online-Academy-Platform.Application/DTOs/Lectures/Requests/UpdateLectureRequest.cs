namespace Online_Academy_Platform.Application.DTOs.Lectures.Requests;

public sealed record UpdateLectureRequest(
    int CourseId,
    string Title,
    string? Description,
    DateTime LectureDate,
    int DurationMinutes);