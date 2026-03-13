using FluentValidation;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Validators.QueriesValidators;

public class LectureFileQueryValidator : AbstractValidator<LectureFileQuery>
{
    public LectureFileQueryValidator()
    {
        RuleFor(x => x.Pagination).SetValidator(new PaginationValidator());

        RuleForEach(x => x.Sorts).SetValidator(new SortCriteriaValidator<LectureFileSortField>());
    }
}