using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Payments.Responses;

public sealed record PaymentResponse(
    int Id,
    int UserId,
    int CourseId,
    int? EnrollmentId,
    int? CouponId,
    decimal OriginalAmount,
    decimal DiscountAmount,
    decimal FinalAmount,
    Currency Currency,
    PaymentMethod PaymentMethod,
    PaymentStatus PaymentStatus,
    string TransactionId,
    DateTime CreatedAt);