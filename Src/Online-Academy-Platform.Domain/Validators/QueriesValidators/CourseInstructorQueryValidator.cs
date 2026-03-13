using FluentValidation;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Validators.QueriesValidators;

public class CourseInstructorQueryValidator : AbstractValidator<CourseInstructorQuery>
{
    public CourseInstructorQueryValidator()
    {
        RuleFor(x => x.Pagination).SetValidator(new PaginationValidator());

        RuleForEach(x => x.Sorts).SetValidator(new SortCriteriaValidator<CourseInstructorSortField>());
    }
}