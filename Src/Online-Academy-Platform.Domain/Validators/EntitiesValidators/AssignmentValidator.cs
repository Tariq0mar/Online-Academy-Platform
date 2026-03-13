using FluentValidation;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class AssignmentValidator : AbstractValidator<Assignment>
{
    public AssignmentValidator()
    {
        RuleFor(a => a.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

        RuleFor(a => a.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters.");

        RuleFor(a => a.MaxGrade)
            .GreaterThan(0).WithMessage("MaxGrade must be greater than 0.");

        RuleFor(a => a.Deadline)
            .GreaterThan(DateTime.Now).WithMessage("Deadline must be in the future.");

        RuleFor(a => a.CourseId)
            .GreaterThan(0).WithMessage("CourseId must be a valid positive integer.");

        RuleFor(a => a.CreatedAt)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("CreatedAt cannot be in the future.");
    }
}