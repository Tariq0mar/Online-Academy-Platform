using FluentValidation;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Validators.QueriesValidators;

public class RoleQueryValidator : AbstractValidator<RoleQuery>
{
    public RoleQueryValidator()
    {
        RuleFor(x => x.Pagination).SetValidator(new PaginationValidator());

        RuleForEach(x => x.Sorts).SetValidator(new SortCriteriaValidator<RoleSortField>());
    }
}