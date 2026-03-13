using FluentValidation;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class CourseValidator : AbstractValidator<Course>
{
    public CourseValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(200)
            .WithMessage("Title must not exceed 200 characters.");

        RuleFor(c => c.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(2000)
            .WithMessage("Description must not exceed 2000 characters.");

        RuleFor(c => c.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price cannot be negative.");

        RuleFor(c => c.Currency)
            .IsInEnum()
            .WithMessage("Currency must be a valid value.");

        RuleFor(c => c.DurationHours)
            .GreaterThan(0)
            .WithMessage("DurationHours must be greater than 0.");

        RuleFor(c => c.Level)
            .IsInEnum()
            .WithMessage("Level must be a valid CourseLevel.");

        RuleFor(c => c.Status)
            .IsInEnum()
            .WithMessage("Status must be a valid CourseStatus.");

        RuleFor(c => c.CreatedAt)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("CreatedAt cannot be in the future.");
    }
}