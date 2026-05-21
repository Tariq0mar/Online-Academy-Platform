using FluentValidation;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class EnrollmentValidator : AbstractValidator<Enrollment>
{
    public EnrollmentValidator()
    {
        RuleFor(e => e.UserId)
            .GreaterThan(0)
            .WithMessage("UserId must be a valid positive number.");

        RuleFor(e => e.CourseId)
            .GreaterThan(0)
            .WithMessage("CourseId must be a valid positive number.");

        RuleFor(e => e.Status)
            .IsInEnum()
            .WithMessage("Status must be a valid EnrollmentStatus.");

        RuleFor(e => e.EnrolledAt)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("EnrolledAt cannot be in the future.");
    }
}
