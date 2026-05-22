using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Coupons.Responses;

public sealed record CouponResponse(
    int Id,
    string Code,
    string? Description,
    DiscountType DiscountType,
    decimal DiscountValue,
    int MaxUses,
    int UsedCount,
    DateTime ValidFrom,
    DateTime ValidUntil,
    bool IsActive,
    DateTime CreatedAt);