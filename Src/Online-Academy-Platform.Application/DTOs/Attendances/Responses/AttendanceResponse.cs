using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Attendances.Responses;

public sealed record AttendanceResponse(
    int Id,
    int LectureId,
    int UserId,
    AttendanceStatus Status,
    DateTime RecordedAt);