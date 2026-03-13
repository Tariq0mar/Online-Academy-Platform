using FluentValidation;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class AssignmentSubmissionValidator : AbstractValidator<AssignmentSubmission>
{
    public AssignmentSubmissionValidator()
    {
        RuleFor(s => s.AssignmentId)
            .GreaterThan(0).WithMessage("AssignmentId must be a valid positive number.");

        RuleFor(s => s.StudentId)
            .GreaterThan(0).WithMessage("StudentId must be a valid positive number.");

        RuleFor(s => s.SubmissionFile)
            .NotEmpty().WithMessage("SubmissionFile is required.")
            .MaximumLength(500).WithMessage("SubmissionFile path must not exceed 500 characters.");

        RuleFor(s => s.SubmissionDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("SubmissionDate cannot be in the future.");

        RuleFor(s => s.Grade)
            .GreaterThanOrEqualTo(0).WithMessage("Grade cannot be negative.")
            .LessThanOrEqualTo(100).WithMessage("Grade cannot exceed 100."); // adjust max if needed

        RuleFor(s => s.Feedback)
            .MaximumLength(2000).WithMessage("Feedback must not exceed 2000 characters.");

        RuleFor(s => s.Status)
            .IsInEnum().WithMessage("Status must be a valid SubmissionStatus.");
    }
}