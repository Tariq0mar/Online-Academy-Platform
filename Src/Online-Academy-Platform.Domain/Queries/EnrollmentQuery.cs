using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class EnrollmentQuery
{
    public int? UserId { get; set; }
    public int? CourseId { get; set; }
    public EnrollmentStatus? Status { get; set; }
    public DateTime? EnrolledAfter { get; set; }
    public DateTime? EnrolledBefore { get; set; }

    public List<SortCriteria<EnrollmentSortField>> Sorts { get; set; } = new();

    public Pagination Pagination { get; set; } = new Pagination();
}