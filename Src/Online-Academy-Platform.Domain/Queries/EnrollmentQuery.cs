using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class EnrollmentQuery
{
    public int? StudentId { get; set; }
    public int? CourseId { get; set; }
    public DateTime? EnrolledAfter { get; set; }
    public DateTime? EnrolledBefore { get; set; }

    public List<SortCriteria<EnrollmentSortField>> Sorts { get; set; } = new();

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}