using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Payments.Requests;

public sealed record UpdatePaymentStatusRequest(
    PaymentStatus PaymentStatus,
    string TransactionId);