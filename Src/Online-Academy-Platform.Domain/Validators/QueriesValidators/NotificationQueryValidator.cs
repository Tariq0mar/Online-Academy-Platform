using FluentValidation;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Validators.QueriesValidators;

public class NotificationQueryValidator : AbstractValidator<NotificationQuery>
{
    public NotificationQueryValidator()
    {
        RuleFor(x => x)
            .Must(x => !x.CreatedAfter.HasValue || !x.CreatedBefore.HasValue || x.CreatedAfter <= x.CreatedBefore)
            .WithMessage("CreatedAfter cannot be later than CreatedBefore.");

        RuleFor(x => x.Pagination).SetValidator(new PaginationValidator());

        RuleForEach(x => x.Sorts).SetValidator(new SortCriteriaValidator<NotificationSortField>());
    }
}