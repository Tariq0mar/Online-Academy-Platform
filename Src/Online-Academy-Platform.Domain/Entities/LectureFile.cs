using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Entities;

public class LectureFile
{
    public int Id { get; set; }

    public int LectureId { get; set; }

    public required string FileUrl { get; set; }

    public FileType FileType { get; set; }

    public Lecture Lecture { get; set; } = null!;
}
