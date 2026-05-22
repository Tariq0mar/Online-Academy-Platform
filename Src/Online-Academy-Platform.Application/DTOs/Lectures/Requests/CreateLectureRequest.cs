using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Lectures.Requests;

public sealed record CreateLectureRequest(
    int CourseId,
    string Title,
    string? Description,
    DateTime LectureDate,
    int DurationMinutes);