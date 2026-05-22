using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.LecturesFiles.Responses;

public sealed record LectureFileResponse(
    int Id,
    int LectureId,
    string FileUrl,
    FileType FileType);