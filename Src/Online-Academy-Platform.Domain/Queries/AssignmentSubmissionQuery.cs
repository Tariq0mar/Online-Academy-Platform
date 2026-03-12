using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class AssignmentSubmissionQuery
{
    public int? AssignmentId { get; set; }
    public int? StudentId { get; set; }
    public SubmissionStatus? Status { get; set; }
    public int? MinGrade { get; set; }
    public int? MaxGrade { get; set; }
    public DateTime? SubmittedAfter { get; set; }
    public DateTime? SubmittedBefore { get; set; }
    
    public List<SortCriteria<AssignmentSubmissionSortField>> Sorts { get; set; } = new();
    
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}