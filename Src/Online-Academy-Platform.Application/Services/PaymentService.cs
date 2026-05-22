using AutoMapper;
using Online_Academy_Platform.Application.DTOs.Payments.Requests;
using Online_Academy_Platform.Application.DTOs.Payments.Responses;
using Online_Academy_Platform.Application.Exceptions;
using Online_Academy_Platform.Application.Interfaces.Services;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Interfaces.Repositories;

namespace Online_Academy_Platform.Application.Services;

public class PaymentService(
    IPaymentRepository repository,
    IUserRepository userRepository,
    ICourseRepository courseRepository,
    IEnrollmentRepository enrollmentRepository,
    ICouponRepository couponRepository,
    IMapper mapper)
    : IPaymentService
{
    public async Task<PaymentResponse> CreatePaymentAsync(CreatePaymentRequest request)
    {
        if (!await userRepository.ExistsAsync(request.UserId))
            throw new NotFoundException(nameof(User), request.UserId);

        if (!await courseRepository.ExistsAsync(request.CourseId))
            throw new NotFoundException(nameof(Course), request.CourseId);

        if (request.EnrollmentId.HasValue
            && !await enrollmentRepository.ExistsAsync(request.EnrollmentId.Value))
            throw new NotFoundException(nameof(Enrollment), request.EnrollmentId.Value);

        if (request.CouponId.HasValue
            && !await couponRepository.ExistsAsync(request.CouponId.Value))
            throw new NotFoundException(nameof(Coupon), request.CouponId.Value);

        var entity = mapper.Map<Payment>(request);
        entity.PaymentStatus = PaymentStatus.Pending;
        entity.CreatedAt = DateTime.UtcNow;

        if (string.IsNullOrWhiteSpace(request.TransactionId))
            entity.TransactionId = Guid.NewGuid().ToString();

        entity.FinalAmount = entity.OriginalAmount - entity.DiscountAmount;

        var created = await repository.AddAsync(entity);

        return mapper.Map<PaymentResponse>(created);
    }

    public async Task<PaymentResponse> GetByTransactionIdAsync(string transactionId)
    {
        var entity = await repository.GetByTransactionIdAsync(transactionId);
        if (entity is null)
            throw new NotFoundException($"Payment with transaction ID '{transactionId}' was not found.");

        return mapper.Map<PaymentResponse>(entity);
    }

    public async Task UpdateStatusAsync(UpdatePaymentStatusRequest request)
    {
        var entity = await repository.GetByTransactionIdAsync(request.TransactionId);
        if (entity is null)
            throw new NotFoundException(
                $"Payment with transaction ID '{request.TransactionId}' was not found.");

        entity.PaymentStatus = request.PaymentStatus;

        if (request.PaymentStatus == PaymentStatus.Completed
            && entity.EnrollmentId.HasValue)
        {
            var enrollment = await enrollmentRepository.GetByIdAsync(entity.EnrollmentId.Value);
            if (enrollment is not null)
            {
                enrollment.Status = EnrollmentStatus.Active;
                await enrollmentRepository.UpdateAsync(enrollment);

                // Increment coupon usage on successful completion
                if (entity.CouponId.HasValue)
                    await couponRepository.IncrementUsedCountAsync(entity.CouponId.Value);
            }
        }

        if (request.PaymentStatus == PaymentStatus.Failed
            && entity.EnrollmentId.HasValue)
        {
            var enrollment = await enrollmentRepository.GetByIdAsync(entity.EnrollmentId.Value);
            if (enrollment is not null)
            {
                enrollment.Status = EnrollmentStatus.Cancelled;
                await enrollmentRepository.UpdateAsync(enrollment);
            }
        }

        await repository.UpdateAsync(entity);
    }

    public async Task CompleteAsync(int paymentId)
    {
        var entity = await repository.GetByIdAsync(paymentId);
        if (entity is null)
            throw new NotFoundException(nameof(Payment), paymentId);

        entity.PaymentStatus = PaymentStatus.Completed;
        await repository.UpdateAsync(entity);

        if (entity.EnrollmentId.HasValue)
        {
            var enrollment = await enrollmentRepository.GetByIdAsync(entity.EnrollmentId.Value);
            if (enrollment is not null)
            {
                enrollment.Status = EnrollmentStatus.Active;
                await enrollmentRepository.UpdateAsync(enrollment);
            }

            if (entity.CouponId.HasValue)
                await couponRepository.IncrementUsedCountAsync(entity.CouponId.Value);
        }
    }

    public async Task FailAsync(int paymentId)
    {
        var entity = await repository.GetByIdAsync(paymentId);
        if (entity is null)
            throw new NotFoundException(nameof(Payment), paymentId);

        entity.PaymentStatus = PaymentStatus.Failed;
        await repository.UpdateAsync(entity);

        if (entity.EnrollmentId.HasValue)
        {
            var enrollment = await enrollmentRepository.GetByIdAsync(entity.EnrollmentId.Value);
            if (enrollment is not null)
            {
                enrollment.Status = EnrollmentStatus.Cancelled;
                await enrollmentRepository.UpdateAsync(enrollment);
            }
        }
    }

    public async Task CancelAsync(int paymentId)
    {
        var entity = await repository.GetByIdAsync(paymentId);
        if (entity is null)
            throw new NotFoundException(nameof(Payment), paymentId);

        entity.PaymentStatus = PaymentStatus.Cancelled;
        await repository.UpdateAsync(entity);

        if (entity.EnrollmentId.HasValue)
        {
            var enrollment = await enrollmentRepository.GetByIdAsync(entity.EnrollmentId.Value);
            if (enrollment is not null)
            {
                enrollment.Status = EnrollmentStatus.Cancelled;
                await enrollmentRepository.UpdateAsync(enrollment);
            }
        }
    }

    public async Task<PaymentResponse> RefundAsync(int paymentId)
    {
        var entity = await repository.GetByIdAsync(paymentId);
        if (entity is null)
            throw new NotFoundException(nameof(Payment), paymentId);

        // Create a refund as a new payment record (negative)
        var refund = new Payment
        {
            UserId = entity.UserId,
            CourseId = entity.CourseId,
            EnrollmentId = entity.EnrollmentId,
            CouponId = entity.CouponId,
            OriginalAmount = -entity.FinalAmount,
            DiscountAmount = 0,
            FinalAmount = -entity.FinalAmount,
            Currency = entity.Currency,
            PaymentMethod = entity.PaymentMethod,
            PaymentStatus = PaymentStatus.Completed,
            TransactionId = $"REFUND-{entity.TransactionId}",
            CreatedAt = DateTime.UtcNow
        };

        var created = await repository.AddAsync(refund);

        // Cancel the enrollment if refunded
        if (entity.EnrollmentId.HasValue)
        {
            var enrollment = await enrollmentRepository.GetByIdAsync(entity.EnrollmentId.Value);
            if (enrollment is not null)
            {
                enrollment.Status = EnrollmentStatus.Cancelled;
                await enrollmentRepository.UpdateAsync(enrollment);
            }
        }

        return mapper.Map<PaymentResponse>(created);
    }

    public async Task<IEnumerable<PaymentResponse>> GetByUserIdAsync(int userId)
    {
        if (!await userRepository.ExistsAsync(userId))
            throw new NotFoundException(nameof(User), userId);

        var payments = await repository.GetByUserIdAsync(userId);
        return mapper.Map<IEnumerable<PaymentResponse>>(payments);
    }

    public async Task<IEnumerable<PaymentResponse>> GetByEnrollmentIdAsync(int enrollmentId)
    {
        if (!await enrollmentRepository.ExistsAsync(enrollmentId))
            throw new NotFoundException(nameof(Enrollment), enrollmentId);

        var payments = await repository.GetByEnrollmentIdAsync(enrollmentId);
        return mapper.Map<IEnumerable<PaymentResponse>>(payments);
    }

    public async Task<PaymentResponse> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(Payment), id);

        return mapper.Map<PaymentResponse>(entity);
    }

    public async Task<IEnumerable<PaymentResponse>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();
        return mapper.Map<IEnumerable<PaymentResponse>>(entities);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await repository.ExistsAsync(id))
            throw new NotFoundException(nameof(Payment), id);

        await repository.DeleteAsync(id);
    }
}