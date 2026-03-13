using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class LectureFileQuery
{
    public int? LectureId { get; set; }
    public FileType? FileType { get; set; }

    public List<SortCriteria<LectureFileSortField>> Sorts { get; set; } = new();

    public Pagination Pagination { get; set; } = new Pagination();
}