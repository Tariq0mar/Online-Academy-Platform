using FluentValidation;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class RoleValidator : AbstractValidator<Role>
{
    public RoleValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .WithMessage("Role name is required.")
            .MaximumLength(100)
            .WithMessage("Role name must not exceed 100 characters.");
    }
}