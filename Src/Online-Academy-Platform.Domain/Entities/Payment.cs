using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Entities;

public class Payment
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public int? CouponId { get; set; }

    public decimal OriginalAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal FinalAmount { get; set; }

    public Currency Currency { get; set; } = Currency.USD;

    public PaymentMethod PaymentMethod { get; set; }

    public PaymentStatus PaymentStatus { get; set; }

    public string TransactionId { get; set; }

    public DateTime CreatedAt { get; set; }

    public User Student { get; set; }

    public Course Course { get; set; }

    public Coupon Coupon { get; set; }
}