using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface IPaymentRepository : IQueryableRepository<Payment, PaymentQuery>
{
    Task<Payment?> GetByTransactionIdAsync(string transactionId);

    Task<bool> ExistsByTransactionIdAsync(string transactionId);

    Task<IEnumerable<Payment>> GetByEnrollmentIdAsync(int enrollmentId);
}
