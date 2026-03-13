using FluentValidation;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class PaymentValidator : AbstractValidator<Payment>
{
    public PaymentValidator()
    {
        RuleFor(p => p.StudentId)
            .GreaterThan(0)
            .WithMessage("StudentId must be a valid positive number.");

        RuleFor(p => p.CourseId)
            .GreaterThan(0)
            .WithMessage("CourseId must be a valid positive number.");

        RuleFor(p => p.OriginalAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("OriginalAmount cannot be negative.");

        RuleFor(p => p.DiscountAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("DiscountAmount cannot be negative.");

        RuleFor(p => p.FinalAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("FinalAmount cannot be negative.");

        RuleFor(p => p)
            .Must(p => p.FinalAmount == p.OriginalAmount - p.DiscountAmount)
            .WithMessage("FinalAmount must equal OriginalAmount minus DiscountAmount.");

        RuleFor(p => p.Currency)
            .IsInEnum()
            .WithMessage("Currency must be a valid value.");

        RuleFor(p => p.PaymentMethod)
            .IsInEnum()
            .WithMessage("PaymentMethod must be valid.");

        RuleFor(p => p.PaymentStatus)
            .IsInEnum()
            .WithMessage("PaymentStatus must be valid.");

        RuleFor(p => p.TransactionId)
            .NotEmpty()
            .WithMessage("TransactionId is required.")
            .MaximumLength(200)
            .WithMessage("TransactionId must not exceed 200 characters.");

        RuleFor(p => p.CreatedAt)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("CreatedAt cannot be in the future.");
    }
}