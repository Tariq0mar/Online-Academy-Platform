using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class CertificateQuery
{
    public int? UserId { get; set; }
    public int? CourseId { get; set; }
    public DateTime? IssuedAfter { get; set; }
    public DateTime? IssuedBefore { get; set; }
    
    public List<SortCriteria<CertificateSortField>> Sorts { get; set; } = new();
    
    public Pagination Pagination { get; set; } = new Pagination();
}