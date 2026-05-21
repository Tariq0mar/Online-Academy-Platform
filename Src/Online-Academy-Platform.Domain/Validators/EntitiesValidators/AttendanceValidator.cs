using FluentValidation;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class AttendanceValidator : AbstractValidator<Attendance>
{
    public AttendanceValidator()
    {
        RuleFor(a => a.LectureId)
            .GreaterThan(0)
            .WithMessage("LectureId must be a valid positive number.");

        RuleFor(a => a.UserId)
            .GreaterThan(0)
            .WithMessage("UserId must be a valid positive number.");

        RuleFor(a => a.Status)
            .IsInEnum()
            .WithMessage("Status must be a valid AttendanceStatus value.");
    }
}
