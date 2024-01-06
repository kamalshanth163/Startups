using FluentValidation;

namespace Startups.Application.Startups.Commands.CreateStartup
{
    public class CreateStartupCommandValidator : AbstractValidator<CreateStartupCommand>
    {
        public CreateStartupCommandValidator()
        {
            RuleFor(v => v.Startup.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters");
        }
    }
}
