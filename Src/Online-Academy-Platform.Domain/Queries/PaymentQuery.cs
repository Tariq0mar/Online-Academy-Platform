using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class PaymentQuery
{
    public int? UserId { get; set; }
    public int? EnrollmentId { get; set; }
    public int? CourseId { get; set; }
    public int? CouponId { get; set; }
    public Currency? Currency { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public PaymentStatus? PaymentStatus { get; set; }
    public decimal? MinOriginalAmount { get; set; }
    public decimal? MaxOriginalAmount { get; set; }
    public decimal? MinFinalAmount { get; set; }
    public decimal? MaxFinalAmount { get; set; }
    public DateTime? CreatedAfter { get; set; }
    public DateTime? CreatedBefore { get; set; }

    public List<SortCriteria<PaymentSortField>> Sorts { get; set; } = new();

    public Pagination Pagination { get; set; } = new Pagination();
}