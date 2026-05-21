using FluentValidation;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Validators.QueriesValidators;

public class SortCriteriaValidator<T> : AbstractValidator<SortCriteria<T>> where T : Enum
{
    public SortCriteriaValidator()
    {
        RuleFor(x => x.PropertyName)
            .IsInEnum()
            .WithMessage("Sort field must be a valid attribute value.");

        RuleFor(x => x.Direction)
            .IsInEnum()
            .WithMessage("Sort direction must be Asc or Desc.");
    }
}