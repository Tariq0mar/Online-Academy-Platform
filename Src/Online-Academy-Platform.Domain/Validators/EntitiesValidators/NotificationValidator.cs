using FluentValidation;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class NotificationValidator : AbstractValidator<Notification>
{
    public NotificationValidator()
    {
        RuleFor(n => n.UserId)
            .GreaterThan(0)
            .WithMessage("UserId must be a valid positive number.");

        RuleFor(n => n.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(200)
            .WithMessage("Title must not exceed 200 characters.");

        RuleFor(n => n.Message)
            .NotEmpty()
            .WithMessage("Message is required.")
            .MaximumLength(2000)
            .WithMessage("Message must not exceed 2000 characters.");

        RuleFor(n => n.CreatedAt)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("CreatedAt cannot be in the future.");
    }
}