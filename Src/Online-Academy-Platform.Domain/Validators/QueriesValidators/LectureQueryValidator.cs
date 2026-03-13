using FluentValidation;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Validators.QueriesValidators;

public class LectureQueryValidator : AbstractValidator<LectureQuery>
{
    public LectureQueryValidator()
    {
        RuleFor(x => x)
            .Must(x => !x.LectureAfter.HasValue || !x.LectureBefore.HasValue || x.LectureAfter <= x.LectureBefore)
            .WithMessage("LectureAfter cannot be later than LectureBefore.");

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

        RuleFor(x => x.Pagination).SetValidator(new PaginationValidator());

        RuleForEach(x => x.Sorts).SetValidator(new SortCriteriaValidator<LectureSortField>());
    }
}