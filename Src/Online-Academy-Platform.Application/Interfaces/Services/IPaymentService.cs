using Online_Academy_Platform.Application.DTOs.Payments.Requests;
using Online_Academy_Platform.Application.DTOs.Payments.Responses;

namespace Online_Academy_Platform.Application.Interfaces.Services;

public interface IPaymentService
{
    Task<PaymentResponse> CreatePaymentAsync(CreatePaymentRequest request);

    Task<PaymentResponse> GetByTransactionIdAsync(string transactionId);

    Task UpdateStatusAsync(UpdatePaymentStatusRequest request);

    Task CompleteAsync(int paymentId);

    Task FailAsync(int paymentId);

    Task CancelAsync(int paymentId);

    Task<PaymentResponse> RefundAsync(int paymentId);

    Task<IEnumerable<PaymentResponse>> GetByUserIdAsync(int userId);

    Task<IEnumerable<PaymentResponse>> GetByEnrollmentIdAsync(int enrollmentId);

    Task<PaymentResponse> GetByIdAsync(int id);

    Task<IEnumerable<PaymentResponse>> GetAllAsync();

    Task DeleteAsync(int id);
}