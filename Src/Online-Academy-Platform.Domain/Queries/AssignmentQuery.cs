using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class AssignmentQuery
{
    public int? CourseId { get; set; }
    public int? MinMaxGrade { get; set; }
    public int? MaxMaxGrade { get; set; }
    public DateTime? CreatedBefore { get; set; }
    public DateTime? CreatedAfter { get; set; }
    public DateTime? DeadlineBefore { get; set; }
    public DateTime? DeadlineAfter { get; set; }
    
    public List<SortCriteria<AssignmentSortField>> Sorts { get; set; } = new();
    
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}