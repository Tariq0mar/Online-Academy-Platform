using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Attendances.Requests;

public sealed record RecordAttendanceRequest(
    int LectureId,
    int UserId,
    AttendanceStatus Status);