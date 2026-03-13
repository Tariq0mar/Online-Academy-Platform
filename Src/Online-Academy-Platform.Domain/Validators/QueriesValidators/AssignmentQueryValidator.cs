using FluentValidation;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Validators.QueriesValidators;

public class AssignmentQueryValidator : AbstractValidator<AssignmentQuery>
{
    public AssignmentQueryValidator()
    {
        RuleFor(x => x.MinMaxGrade)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MinMaxGrade.HasValue)
            .WithMessage("MinMaxGrade must be non-negative.");

        RuleFor(x => x.MaxMaxGrade)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MaxMaxGrade.HasValue)
            .WithMessage("MaxMaxGrade must be non-negative.");

        RuleFor(x => x)
            .Must(x => !x.MinMaxGrade.HasValue || !x.MaxMaxGrade.HasValue || x.MinMaxGrade <= x.MaxMaxGrade)
            .WithMessage("MinMaxGrade cannot be greater than MaxMaxGrade.");

        RuleFor(x => x)
            .Must(x => !x.CreatedAfter.HasValue || !x.CreatedBefore.HasValue || x.CreatedAfter <= x.CreatedBefore)
            .WithMessage("CreatedAfter cannot be later than CreatedBefore.");

        RuleFor(x => x)
            .Must(x => !x.DeadlineAfter.HasValue || !x.DeadlineBefore.HasValue || x.DeadlineAfter <= x.DeadlineBefore)
            .WithMessage("DeadlineAfter cannot be later than DeadlineBefore.");

        
        RuleFor(x => x.Pagination).SetValidator(new PaginationValidator());
        
        RuleForEach(x => x.Sorts).SetValidator(new SortCriteriaValidator<AssignmentSortField>());
    }
}