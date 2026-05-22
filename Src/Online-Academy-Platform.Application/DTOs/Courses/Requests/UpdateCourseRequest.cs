using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Courses.Requests;

public sealed record UpdateCourseRequest(
    string Title,
    string Description,
    decimal Price,
    Currency Currency,
    int DurationHours,
    CourseLevel Level);