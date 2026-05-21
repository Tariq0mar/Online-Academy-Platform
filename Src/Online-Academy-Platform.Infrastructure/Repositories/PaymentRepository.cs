using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Domain.Queries;
using Online_Academy_Platform.Infrastructure.Persistence;
using Online_Academy_Platform.Infrastructure.Repositories.Common;
using Online_Academy_Platform.Infrastructure.Repositories.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories;

public class PaymentRepository(ApplicationDbContext context)
    : QueryableRepository<Payment, PaymentQuery>(context), IPaymentRepository
{
    protected override IQueryable<Payment> ApplyQuery(IQueryable<Payment> query, PaymentQuery queryParams) =>
        PaymentQueryApplicator.Apply(query, queryParams);

    protected override int GetPage(PaymentQuery query) => QueryHelper.GetPage(query.Pagination);

    protected override int GetPageSize(PaymentQuery query) => QueryHelper.GetPageSize(query.Pagination);

    public async Task<Payment?> GetByTransactionIdAsync(string transactionId) =>
        await DbSet.FirstOrDefaultAsync(p => p.TransactionId == transactionId);

    public async Task<bool> ExistsByTransactionIdAsync(string transactionId) =>
        await DbSet.AnyAsync(p => p.TransactionId == transactionId);

    public async Task<IEnumerable<Payment>> GetByEnrollmentIdAsync(int enrollmentId) =>
        await DbSet.Where(p => p.EnrollmentId == enrollmentId).ToListAsync();

    public async Task<IEnumerable<Payment>> GetByUserIdAsync(int userId) =>
        await DbSet.Where(p => p.UserId == userId).ToListAsync();

    public async Task<IEnumerable<Payment>> GetByCourseIdAsync(int courseId) =>
        await DbSet.Where(p => p.CourseId == courseId).ToListAsync();

    public async Task<Payment?> GetLatestByUserAndCourseAsync(int userId, int courseId) =>
        await DbSet
            .Where(p => p.UserId == userId && p.CourseId == courseId)
            .OrderByDescending(p => p.CreatedAt)
            .FirstOrDefaultAsync();

    public async Task<bool> UpdateStatusAsync(int paymentId, PaymentStatus status)
    {
        var payment = await GetByIdAsync(paymentId);
        if (payment is null)
        {
            return false;
        }

        payment.PaymentStatus = status;
        await UpdateAsync(payment);
        return true;
    }
}
