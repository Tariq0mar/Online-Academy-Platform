using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface IPaymentRepository : IQueryableRepository<Payment, PaymentQuery>
{
    Task<Payment?> GetByTransactionIdAsync(string transactionId);

    Task<bool> ExistsByTransactionIdAsync(string transactionId);

    Task<IEnumerable<Payment>> GetByEnrollmentIdAsync(int enrollmentId);

    Task<IEnumerable<Payment>> GetByUserIdAsync(int userId);

    Task<IEnumerable<Payment>> GetByCourseIdAsync(int courseId);

    Task<Payment?> GetLatestByUserAndCourseAsync(int userId, int courseId);

    Task<bool> UpdateStatusAsync(int paymentId, PaymentStatus status);
}
