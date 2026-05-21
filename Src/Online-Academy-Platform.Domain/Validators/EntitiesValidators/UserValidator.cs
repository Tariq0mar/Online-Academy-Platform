using FluentValidation;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(200)
            .WithMessage("Name must not exceed 200 characters.");

        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .MaximumLength(200)
            .WithMessage("Email must not exceed 200 characters.")
            .EmailAddress()
            .WithMessage("Email must be a valid email address.");

        RuleFor(u => u.PasswordHash)
            .NotEmpty()
            .WithMessage("PasswordHash is required.")
            .MinimumLength(20)
            .WithMessage("PasswordHash appears invalid (too short for a typical hash).")
            .MaximumLength(500)
            .WithMessage("PasswordHash must not exceed 500 characters.");

        RuleFor(u => u.Phone)
            .NotEmpty()
            .WithMessage("Phone is required.")
            .Matches(@"^\+?[0-9]{7,15}$")
            .WithMessage("Phone must be a valid phone number.");

        RuleFor(u => u.ProfilePicture)
            .MaximumLength(500)
            .When(u => !string.IsNullOrEmpty(u.ProfilePicture))
            .WithMessage("ProfilePicture URL must not exceed 500 characters.");

        RuleFor(u => u.Role)
            .IsInEnum()
            .WithMessage("Role must be a valid UserRole (Admin, Instructor, or Student).");

        RuleFor(u => u.CreatedAt)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("CreatedAt cannot be in the future.");
    }
}
