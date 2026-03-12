using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class CouponQuery
{
    public string? Code { get; set; }
    public DiscountType? DiscountType { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? ValidFromAfter { get; set; }
    public DateTime? ValidFromBefore { get; set; }
    public DateTime? ValidUntilAfter { get; set; }
    public DateTime? ValidUntilBefore { get; set; }

    public List<SortCriteria<CouponSortField>> Sorts { get; set; } = new();

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}