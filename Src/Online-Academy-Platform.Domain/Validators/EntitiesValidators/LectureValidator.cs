using FluentValidation;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class LectureValidator : AbstractValidator<Lecture>
{
    public LectureValidator()
    {
        RuleFor(l => l.CourseId)
            .GreaterThan(0)
            .WithMessage("CourseId must be a valid positive number.");

        RuleFor(l => l.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(200)
            .WithMessage("Title must not exceed 200 characters.");

        RuleFor(l => l.Description)
            .MaximumLength(2000)
            .WithMessage("Description must not exceed 2000 characters.");

        RuleFor(l => l.LectureDate)
            .LessThanOrEqualTo(DateTime.Now.AddYears(5))
            .WithMessage("LectureDate seems invalid.");

        RuleFor(l => l.DurationMinutes)
            .GreaterThan(0)
            .WithMessage("DurationMinutes must be greater than 0.")
            .LessThanOrEqualTo(600)
            .WithMessage("DurationMinutes cannot exceed 600 minutes.");
    }
}