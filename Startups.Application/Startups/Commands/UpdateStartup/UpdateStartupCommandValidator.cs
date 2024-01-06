using FluentValidation;

namespace Startups.Application.Startups.Commands.UpdateStartup
{
    public class UpdateStartupCommandValidator : AbstractValidator<UpdateStartupCommand>
    {
        public UpdateStartupCommandValidator()
        {
            RuleFor(v => v.Startup.Id)
                .NotEmpty()
                .WithSeverity(Severity.Error)
                .WithMessage("Id is required");

            RuleFor(v => v.Startup.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters");
        }
    }
}
