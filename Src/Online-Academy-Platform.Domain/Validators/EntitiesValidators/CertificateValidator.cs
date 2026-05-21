using FluentValidation;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class CertificateValidator : AbstractValidator<Certificate>
{
    public CertificateValidator()
    {
        RuleFor(c => c.UserId)
            .GreaterThan(0)
            .WithMessage("UserId must be a valid positive number.");

        RuleFor(c => c.CourseId)
            .GreaterThan(0)
            .WithMessage("CourseId must be a valid positive number.");

        RuleFor(c => c.CertificateUrl)
            .NotEmpty()
            .WithMessage("CertificateUrl is required.")
            .MaximumLength(500)
            .WithMessage("CertificateUrl must not exceed 500 characters.");

        RuleFor(c => c.IssueDate)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("IssueDate cannot be in the future.");
    }
}
