using MediatR;
using Startups.Application.Startups.Dtos;

namespace Startups.Application.Startups.Commands.UpdateStartup
{
    public class UpdateStartupCommand : IRequest<StartupDto>
    {
        public UpdateStartupDto Startup { get; set; } = null!;

        public UpdateStartupCommand(UpdateStartupDto startup)
        {
            Startup = startup;
        }
    }
}
