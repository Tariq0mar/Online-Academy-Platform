using FluentValidation;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class CouponValidator : AbstractValidator<Coupon>
{
    public CouponValidator()
    {
        RuleFor(c => c.Code)
            .NotEmpty().WithMessage("Coupon code is required.")
            .MaximumLength(50).WithMessage("Coupon code must not exceed 50 characters.");

        RuleFor(c => c.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        RuleFor(c => c.DiscountType)
            .IsInEnum().WithMessage("Invalid discount type.");

        RuleFor(c => c.DiscountValue)
            .GreaterThan(0).WithMessage("Discount value must be greater than 0.");

        RuleFor(c => c.DiscountValue)
            .LessThanOrEqualTo(100)
            .When(c => c.DiscountType == DiscountType.Percentage)
            .WithMessage("Percentage discount cannot exceed 100.");

        RuleFor(c => c.MaxUses)
            .GreaterThanOrEqualTo(0)
            .WithMessage("MaxUses cannot be negative.");

        RuleFor(c => c.UsedCount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("UsedCount cannot be negative.");

        RuleFor(c => c)
            .Must(c => c.UsedCount <= c.MaxUses || c.MaxUses == 0)
            .WithMessage("UsedCount cannot exceed MaxUses.");

        RuleFor(c => c.ValidFrom)
            .LessThanOrEqualTo(c => c.ValidUntil)
            .WithMessage("ValidFrom must be before ValidUntil.");

        RuleFor(c => c.ValidUntil)
            .GreaterThan(c => c.ValidFrom)
            .WithMessage("ValidUntil must be after ValidFrom.");

        RuleFor(c => c.CreatedAt)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("CreatedAt cannot be in the future.");
    }
}