namespace Online_Academy_Platform.Application.DTOs.LecturesFiles.Requests;

public class UpdateLectureFileRequest
{
    public required string FileName { get; set; }

    public required string FileUrl { get; set; }

    public long FileSize { get; set; }
}