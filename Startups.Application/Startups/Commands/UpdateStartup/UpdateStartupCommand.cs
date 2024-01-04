using MediatR;
using Startups.Application.Startups.Dtos;

namespace Startups.Application.Startups.Commands.UpdateStartup
{
    public class UpdateStartupCommand : IRequest<StartupDto>
    {
        public Guid Id { get; set; }
        public UpdateStartupDto Startup { get; set; } = null!;
    }
}
