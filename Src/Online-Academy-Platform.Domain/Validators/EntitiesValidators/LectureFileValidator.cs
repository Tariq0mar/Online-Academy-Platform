using FluentValidation;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Domain.Validators.EntitiesValidators;

public class LectureFileValidator : AbstractValidator<LectureFile>
{
    public LectureFileValidator()
    {
        RuleFor(f => f.LectureId)
            .GreaterThan(0)
            .WithMessage("LectureId must be a valid positive number.");

        RuleFor(f => f.FileUrl)
            .NotEmpty()
            .WithMessage("FileUrl is required.")
            .MaximumLength(500)
            .WithMessage("FileUrl must not exceed 500 characters.");

        RuleFor(f => f.FileType)
            .IsInEnum()
            .WithMessage("FileType must be a valid FileType.");
    }
}