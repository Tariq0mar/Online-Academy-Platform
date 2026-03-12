using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class CertificateQuery
{
    public int? StudentId { get; set; }
    public int? CourseId { get; set; }
    public DateTime? IssuedAfter { get; set; }
    public DateTime? IssuedBefore { get; set; }
    
    public List<SortCriteria<CertificateSortField>> Sorts { get; set; } = new();
    
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}