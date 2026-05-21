using FluentValidation;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class CourseInstructorValidator : AbstractValidator<CourseInstructor>
{
    public CourseInstructorValidator()
    {
        RuleFor(ci => ci.CourseId)
            .GreaterThan(0)
            .WithMessage("CourseId must be a valid positive number.");

        RuleFor(ci => ci.InstructorId)
            .GreaterThan(0)
            .WithMessage("InstructorId must be a valid positive number.");

        RuleFor(ci => ci.AssignedAt)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("AssignedAt cannot be in the future.");
    }
}
