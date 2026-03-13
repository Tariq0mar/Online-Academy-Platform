using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class CourseQuery
{
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public Currency? Currency { get; set; }
    public int? MinDuration { get; set; }
    public int? MaxDuration { get; set; }
    public CourseLevel? Level { get; set; }
    public CourseStatus? Status { get; set; }
    public DateTime? CreatedAfter { get; set; }
    public DateTime? CreatedBefore { get; set; }

    public List<SortCriteria<CourseSortField>> Sorts { get; set; } = new();

    public Pagination Pagination { get; set; } = new Pagination();
}