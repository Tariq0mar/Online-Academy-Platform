using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class LectureQuery
{
    public int? CourseId { get; set; }
    public DateTime? LectureAfter { get; set; }
    public DateTime? LectureBefore { get; set; }
    public int? MinDuration { get; set; }
    public int? MaxDuration { get; set; }

    public List<SortCriteria<LectureSortField>> Sorts { get; set; } = new();

    public Pagination Pagination { get; set; } = new Pagination();
}