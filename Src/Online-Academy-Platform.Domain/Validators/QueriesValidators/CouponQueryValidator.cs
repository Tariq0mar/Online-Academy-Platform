using FluentValidation;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Validators.QueriesValidators;

public class CouponQueryValidator : AbstractValidator<CouponQuery>
{
    public CouponQueryValidator()
    {
        RuleFor(x => x)
            .Must(x => !x.ValidFromAfter.HasValue || !x.ValidFromBefore.HasValue || x.ValidFromAfter <= x.ValidFromBefore)
            .WithMessage("ValidFromAfter cannot be later than ValidFromBefore.");

        RuleFor(x => x)
            .Must(x => !x.ValidUntilAfter.HasValue || !x.ValidUntilBefore.HasValue || x.ValidUntilAfter <= x.ValidUntilBefore)
            .WithMessage("ValidUntilAfter cannot be later than ValidUntilBefore.");

        RuleFor(x => x.Pagination).SetValidator(new PaginationValidator());

        RuleForEach(x => x.Sorts).SetValidator(new SortCriteriaValidator<CouponSortField>());
    }
}