using FluentValidation;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Validators.QueriesValidators;

public class AssignmentSubmissionQueryValidator : AbstractValidator<AssignmentSubmissionQuery>
{
    public AssignmentSubmissionQueryValidator()
    {
        RuleFor(x => x.MinGrade)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MinGrade.HasValue)
            .WithMessage("MinGrade must be non-negative.");

        RuleFor(x => x.MaxGrade)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MaxGrade.HasValue)
            .WithMessage("MaxGrade must be non-negative.");

        RuleFor(x => x)
            .Must(x => !x.MinGrade.HasValue || !x.MaxGrade.HasValue || x.MinGrade <= x.MaxGrade)
            .WithMessage("MinGrade cannot be greater than MaxGrade.");

        RuleFor(x => x)
            .Must(x => !x.SubmittedAfter.HasValue || !x.SubmittedBefore.HasValue ||
                       x.SubmittedAfter <= x.SubmittedBefore)
            .WithMessage("SubmittedAfter cannot be later than SubmittedBefore.");

        RuleFor(x => x.Status)
            .IsInEnum()
            .When(x => x.Status.HasValue)
            .WithMessage("Status must be a valid SubmissionStatus.");

        RuleFor(x => x.Pagination).SetValidator(new PaginationValidator());

        RuleForEach(x => x.Sorts).SetValidator(new SortCriteriaValidator<AssignmentSubmissionSortField>());
    }
}