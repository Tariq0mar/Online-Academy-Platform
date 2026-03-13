using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class CourseInstructorQuery
{
    public int? CourseId { get; set; }
    public int? InstructorId { get; set; }

    public List<SortCriteria<CourseInstructorSortField>> Sorts { get; set; } = new();

    public Pagination Pagination { get; set; } = new Pagination();
}