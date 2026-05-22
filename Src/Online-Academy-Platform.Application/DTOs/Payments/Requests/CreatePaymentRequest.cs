using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Payments.Requests;

public sealed record CreatePaymentRequest(
    int UserId,
    int CourseId,
    decimal OriginalAmount,
    decimal DiscountAmount,
    Currency Currency,
    PaymentMethod PaymentMethod,
    int? EnrollmentId,
    int? CouponId,
    string? TransactionId);