using Online_Academy_Platform.Application.DTOs.Coupons.Requests;
using Online_Academy_Platform.Application.DTOs.Coupons.Responses;

namespace Online_Academy_Platform.Application.Interfaces.Services;

public interface ICouponService
{
    Task<CouponResponse> GetByCodeAsync(string code);

    Task<bool> IsValidAsync(string code, DateTime? at = null);

    Task<CouponDiscountResponse> CalculateDiscountAsync(decimal originalAmount, string couponCode);

    Task<IEnumerable<CouponResponse>> GetActiveCouponsAsync();

    Task DeactivateAsync(int couponId);

    Task<bool> ValidateForCourseAsync(string code, int courseId);

    Task<CouponResponse> AddAsync(CreateCouponRequest request);

    Task<CouponResponse> GetByIdAsync(int id);

    Task<IEnumerable<CouponResponse>> GetAllAsync();

    Task<CouponResponse> UpdateAsync(int id, UpdateCouponRequest request);

    Task DeleteAsync(int id);
}