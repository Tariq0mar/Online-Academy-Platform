using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Courses.Responses;

public sealed record CourseResponse(
    int Id,
    string Title,
    string Description,
    decimal Price,
    Currency Currency,
    int DurationHours,
    CourseLevel Level,
    CourseStatus Status,
    DateTime CreatedAt);