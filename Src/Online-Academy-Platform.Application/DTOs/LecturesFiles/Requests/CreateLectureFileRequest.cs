using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.LecturesFiles.Requests;

public sealed record CreateLectureFileRequest(int LectureId, string FileUrl, FileType FileType);