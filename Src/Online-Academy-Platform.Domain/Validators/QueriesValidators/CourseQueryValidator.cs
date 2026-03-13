using FluentValidation;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Validators.QueriesValidators;

public class CourseQueryValidator : AbstractValidator<CourseQuery>
{
    public CourseQueryValidator()
    {
        RuleFor(x => x.MinPrice)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MinPrice.HasValue)
            .WithMessage("MinPrice must be non-negative.");

        RuleFor(x => x.MaxPrice)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MaxPrice.HasValue)
            .WithMessage("MaxPrice must be non-negative.");

        RuleFor(x => x)
            .Must(x => !x.MinPrice.HasValue || !x.MaxPrice.HasValue || x.MinPrice <= x.MaxPrice)
            .WithMessage("MinPrice cannot be greater than MaxPrice.");

        RuleFor(x => x.MinDuration)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MinDuration.HasValue)
            .WithMessage("MinDuration must be non-negative.");

        RuleFor(x => x.MaxDuration)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MaxDuration.HasValue)
            .WithMessage("MaxDuration must be non-negative.");

        RuleFor(x => x)
            .Must(x => !x.MinDuration.HasValue || !x.MaxDuration.HasValue || x.MinDuration <= x.MaxDuration)
            .WithMessage("MinDuration cannot be greater than MaxDuration.");

        RuleFor(x => x)
            .Must(x => !x.CreatedAfter.HasValue || !x.CreatedBefore.HasValue || x.CreatedAfter <= x.CreatedBefore)
            .WithMessage("CreatedAfter cannot be later than CreatedBefore.");

        RuleFor(x => x.Pagination).SetValidator(new PaginationValidator());

        RuleForEach(x => x.Sorts).SetValidator(new SortCriteriaValidator<CourseSortField>());
    }
}