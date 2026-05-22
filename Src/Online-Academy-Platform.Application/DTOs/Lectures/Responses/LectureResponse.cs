using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Lectures.Responses;

public sealed record LectureResponse(
    int Id,
    int CourseId,
    string Title,
    string? Description,
    DateTime LectureDate,
    int DurationMinutes);