using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface IPaymentService : ISearchableService<Payment, PaymentQuery>
{
    Task<Payment> CreatePaymentAsync(Payment payment);

    Task<Payment?> GetByTransactionIdAsync(string transactionId);

    Task UpdateStatusAsync(int paymentId, PaymentStatus status);

    Task CompleteAsync(int paymentId);

    Task FailAsync(int paymentId);

    Task CancelAsync(int paymentId);
}
