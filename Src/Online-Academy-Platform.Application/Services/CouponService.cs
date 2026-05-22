using AutoMapper;
using Online_Academy_Platform.Application.DTOs.Coupons.Requests;
using Online_Academy_Platform.Application.DTOs.Coupons.Responses;
using Online_Academy_Platform.Application.Exceptions;
using Online_Academy_Platform.Application.Interfaces.Services;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Interfaces.Repositories;

namespace Online_Academy_Platform.Application.Services;

public class CouponService(
    ICouponRepository repository,
    ICourseRepository courseRepository,
    IMapper mapper)
    : ICouponService
{
    public async Task<CouponResponse> GetByCodeAsync(string code)
    {
        var entity = await repository.GetByCodeAsync(code);
        if (entity is null)
            throw new NotFoundException($"Coupon with code '{code}' was not found.");

        return mapper.Map<CouponResponse>(entity);
    }

    public async Task<bool> IsValidAsync(string code, DateTime? at = null)
    {
        var entity = await repository.GetByCodeAsync(code);
        if (entity is null)
            return false;

        var checkDate = at ?? DateTime.UtcNow;

        return entity.IsActive
            && entity.UsedCount < entity.MaxUses
            && checkDate >= entity.ValidFrom
            && checkDate <= entity.ValidUntil;
    }

    public async Task<CouponDiscountResponse> CalculateDiscountAsync(decimal originalAmount, string couponCode)
    {
        var entity = await repository.GetByCodeAsync(couponCode);
        if (entity is null)
            throw new NotFoundException($"Coupon '{couponCode}' not found.");

        if (!await IsValidAsync(couponCode))
            throw new ValidationException($"Coupon '{couponCode}' is not valid.");

        var discountAmount = entity.DiscountType switch
        {
            DiscountType.Percentage => originalAmount * entity.DiscountValue / 100,
            DiscountType.FixedAmount => entity.DiscountValue,
            _ => 0
        };

        var finalAmount = Math.Max(originalAmount - discountAmount, 0);

        return new CouponDiscountResponse
        {
            DiscountAmount = discountAmount,
            FinalAmount = finalAmount
        };
    }

    public async Task<IEnumerable<CouponResponse>> GetActiveCouponsAsync()
    {
        var all = await repository.GetAllAsync();
        var active = all.Where(c =>
            c.IsActive
            && c.UsedCount < c.MaxUses
            && DateTime.UtcNow >= c.ValidFrom
            && DateTime.UtcNow <= c.ValidUntil);

        return mapper.Map<IEnumerable<CouponResponse>>(active);
    }

    public async Task DeactivateAsync(int couponId)
    {
        var entity = await repository.GetByIdAsync(couponId);
        if (entity is null)
            throw new NotFoundException(nameof(Coupon), couponId);

        entity.IsActive = false;
        await repository.UpdateAsync(entity);
    }

    public async Task<bool> ValidateForCourseAsync(string code, int courseId)
    {
        if (!await courseRepository.ExistsAsync(courseId))
            throw new NotFoundException(nameof(Course), courseId);

        return await IsValidAsync(code);
    }

    public async Task<CouponResponse> AddAsync(CreateCouponRequest request)
    {
        if (await repository.ExistsByCodeAsync(request.Code))
            throw new ValidationException($"Coupon code '{request.Code}' already exists.");

        var entity = mapper.Map<Coupon>(request);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UsedCount = 0;
        entity.IsActive = true;

        var created = await repository.AddAsync(entity);
        return mapper.Map<CouponResponse>(created);
    }

    public async Task<CouponResponse> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(Coupon), id);

        return mapper.Map<CouponResponse>(entity);
    }

    public async Task<IEnumerable<CouponResponse>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();
        return mapper.Map<IEnumerable<CouponResponse>>(entities);
    }

    public async Task<CouponResponse> UpdateAsync(int id, UpdateCouponRequest request)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(Coupon), id);

        mapper.Map(request, entity);
        await repository.UpdateAsync(entity);

        return mapper.Map<CouponResponse>(entity);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await repository.ExistsAsync(id))
            throw new NotFoundException(nameof(Coupon), id);

        await repository.DeleteAsync(id);
    }
}