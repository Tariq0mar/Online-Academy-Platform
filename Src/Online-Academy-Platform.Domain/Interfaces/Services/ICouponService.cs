using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface ICouponService : ISearchableService<Coupon, CouponQuery>
{
    Task<Coupon?> GetByCodeAsync(string code);

    Task<bool> IsValidAsync(string code, DateTime? at = null);

    Task<(decimal discountAmount, decimal finalAmount)> CalculateDiscountAsync(
        decimal originalAmount,
        string couponCode);
}
