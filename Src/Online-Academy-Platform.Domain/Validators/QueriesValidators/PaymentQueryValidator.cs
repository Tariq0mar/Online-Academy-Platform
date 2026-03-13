using FluentValidation;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Validators.QueriesValidators;

public class PaymentQueryValidator : AbstractValidator<PaymentQuery>
{
    public PaymentQueryValidator()
    {
        RuleFor(x => x.MinFOriginalAmount)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MinFOriginalAmount.HasValue)
            .WithMessage("MinFOriginalAmount must be non-negative.");

        RuleFor(x => x.MaxFOriginalAmount)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MaxFOriginalAmount.HasValue)
            .WithMessage("MaxFOriginalAmount must be non-negative.");

        RuleFor(x => x)
            .Must(x => !x.MinFOriginalAmount.HasValue || !x.MaxFOriginalAmount.HasValue || x.MinFOriginalAmount <= x.MaxFOriginalAmount)
            .WithMessage("MinFOriginalAmount cannot be greater than MaxFOriginalAmount.");

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

        RuleFor(x => x.Pagination).SetValidator(new PaginationValidator());

        RuleForEach(x => x.Sorts).SetValidator(new SortCriteriaValidator<PaymentSortField>());
    }
}