using FluentValidation;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class AssignmentSubmissionValidator : AbstractValidator<AssignmentSubmission>
{
    public AssignmentSubmissionValidator()
    {
        RuleFor(s => s.AssignmentId)
            .GreaterThan(0).WithMessage("AssignmentId must be a valid positive number.");

        RuleFor(s => s.UserId)
            .GreaterThan(0).WithMessage("UserId must be a valid positive number.");

        RuleFor(s => s.SubmissionFile)
            .NotEmpty().WithMessage("SubmissionFile is required.")
            .MaximumLength(500).WithMessage("SubmissionFile path must not exceed 500 characters.");

        RuleFor(s => s.SubmissionDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("SubmissionDate cannot be in the future.");

        RuleFor(s => s.Grade)
            .NotNull()
            .When(s => s.Status == SubmissionStatus.Graded)
            .WithMessage("Grade is required when status is Graded.");

        RuleFor(s => s.Grade)
            .Null()
            .When(s => s.Status == SubmissionStatus.Pending)
            .WithMessage("Grade must be null while submission is Pending.");

        RuleFor(s => s.Grade)
            .GreaterThanOrEqualTo(0)
            .When(s => s.Grade.HasValue)
            .WithMessage("Grade cannot be negative.");

        RuleFor(s => s.Feedback)
            .MaximumLength(2000).WithMessage("Feedback must not exceed 2000 characters.");

        RuleFor(s => s.Status)
            .IsInEnum().WithMessage("Status must be a valid SubmissionStatus.");
    }
}
