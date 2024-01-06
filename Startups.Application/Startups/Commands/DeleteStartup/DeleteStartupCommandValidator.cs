using FluentValidation;

namespace Startups.Application.Startups.Commands.DeleteStartup
{
    public class DeleteStartupCommandValidator : AbstractValidator<DeleteStartupCommand>
    {
        public DeleteStartupCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Id is required")
                .WithSeverity(Severity.Error);
        }
    }
}