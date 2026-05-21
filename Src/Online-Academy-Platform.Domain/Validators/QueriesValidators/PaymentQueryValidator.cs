using FluentValidation;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Validators.QueriesValidators;

public class PaymentQueryValidator : AbstractValidator<PaymentQuery>
{
    public PaymentQueryValidator()
    {
        RuleFor(x => x.MinOriginalAmount)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MinOriginalAmount.HasValue)
            .WithMessage("MinOriginalAmount must be non-negative.");

        RuleFor(x => x.MaxOriginalAmount)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MaxOriginalAmount.HasValue)
            .WithMessage("MaxOriginalAmount must be non-negative.");

        RuleFor(x => x)
            .Must(x => !x.MinOriginalAmount.HasValue || !x.MaxOriginalAmount.HasValue || x.MinOriginalAmount <= x.MaxOriginalAmount)
            .WithMessage("MinOriginalAmount cannot be greater than MaxOriginalAmount.");

        RuleFor(x => x.MinFinalAmount)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MinFinalAmount.HasValue)
            .WithMessage("MinFinalAmount must be non-negative.");

        RuleFor(x => x.MaxFinalAmount)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MaxFinalAmount.HasValue)
            .WithMessage("MaxFinalAmount must be non-negative.");

        RuleFor(x => x)
            .Must(x => !x.MinFinalAmount.HasValue || !x.MaxFinalAmount.HasValue || x.MinFinalAmount <= x.MaxFinalAmount)
            .WithMessage("MinFinalAmount cannot be greater than MaxFinalAmount.");

        RuleFor(x => x)
            .Must(x => !x.CreatedAfter.HasValue || !x.CreatedBefore.HasValue || x.CreatedAfter <= x.CreatedBefore)
            .WithMessage("CreatedAfter cannot be later than CreatedBefore.");

        RuleFor(x => x.Currency)
            .IsInEnum()
            .When(x => x.Currency.HasValue)
            .WithMessage("Currency must be a valid value.");

        RuleFor(x => x.PaymentMethod)
            .IsInEnum()
            .When(x => x.PaymentMethod.HasValue)
            .WithMessage("PaymentMethod must be a valid value.");

        RuleFor(x => x.PaymentStatus)
            .IsInEnum()
            .When(x => x.PaymentStatus.HasValue)
            .WithMessage("PaymentStatus must be a valid value.");

        RuleFor(x => x.Pagination).SetValidator(new PaginationValidator());

        RuleForEach(x => x.Sorts).SetValidator(new SortCriteriaValidator<PaymentSortField>());
    }
}
