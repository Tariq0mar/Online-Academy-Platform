using FluentValidation;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Validators.QueriesValidators;

public class CertificateQueryValidator : AbstractValidator<CertificateQuery>
{
    public CertificateQueryValidator()
    {
        RuleFor(x => x)
            .Must(x => !x.IssuedAfter.HasValue || !x.IssuedBefore.HasValue || x.IssuedAfter <= x.IssuedBefore)
            .WithMessage("IssuedAfter cannot be later than IssuedBefore.");

        RuleFor(x => x.Pagination).SetValidator(new PaginationValidator());

        RuleForEach(x => x.Sorts).SetValidator(new SortCriteriaValidator<CertificateSortField>());
    }
}