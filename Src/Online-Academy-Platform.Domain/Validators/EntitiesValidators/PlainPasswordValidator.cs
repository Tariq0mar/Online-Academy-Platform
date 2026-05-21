using FluentValidation;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class PlainPasswordValidator : AbstractValidator<string>
{
    public PlainPasswordValidator()
    {
        RuleFor(p => p)
            .NotEmpty()
            .WithMessage("Password is required.")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long.")
            .MaximumLength(128)
            .WithMessage("Password must not exceed 128 characters.");
    }
}
