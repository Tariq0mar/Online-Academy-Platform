using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Entities;

public class Payment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CourseId { get; set; }

    public int? EnrollmentId { get; set; }

    public int? CouponId { get; set; }

    public decimal OriginalAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal FinalAmount { get; set; }

    public Currency Currency { get; set; } = Currency.USD;

    public PaymentMethod PaymentMethod { get; set; }

    public PaymentStatus PaymentStatus { get; set; }

    public required string TransactionId { get; set; }

    public DateTime CreatedAt { get; set; }

    public User User { get; set; } = null!;

    public Course Course { get; set; } = null!;

    public Enrollment? Enrollment { get; set; }

    public Coupon? Coupon { get; set; }
}
