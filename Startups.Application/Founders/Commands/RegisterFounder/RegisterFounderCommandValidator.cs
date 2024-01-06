using FluentValidation;

namespace Startups.Application.Founders.Commands.RegisterFounder
{
    public class RegisterFounderCommandValidator : AbstractValidator<RegisterFounderCommand>
    {
        public RegisterFounderCommandValidator()
        {
            RuleFor(v => v.Founder.Email)
                .NotEmpty().WithMessage("Email is required")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters");

            RuleFor(v => v.Founder.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters");

            RuleFor(v => v.Founder.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must have 8 characters atleast")
                .WithSeverity(Severity.Warning);                
        }
    }
}

