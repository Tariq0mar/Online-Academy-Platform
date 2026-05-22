using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Coupons.Requests;

public sealed record UpdateCouponRequest(
    string? Description,
    DiscountType DiscountType,
    decimal DiscountValue,
    int MaxUses,
    DateTime ValidFrom,
    DateTime ValidUntil,
    bool IsActive);