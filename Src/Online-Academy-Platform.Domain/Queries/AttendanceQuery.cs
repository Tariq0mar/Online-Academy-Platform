using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class AttendanceQuery
{
    public int? LectureId { get; set; }
    public int? StudentId { get; set; }
    public AttendanceStatus? Status { get; set; }
    
    public List<SortCriteria<AttendanceSortField>> Sorts { get; set; } = new();
    
    public Pagination Pagination { get; set; } = new Pagination();
}