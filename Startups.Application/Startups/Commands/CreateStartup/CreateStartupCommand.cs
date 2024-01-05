using MediatR;
using Startups.Application.Startups.Dtos;

namespace Startups.Application.Startups.Commands.CreateStartup
{
    public class CreateStartupCommand : IRequest<StartupDto>
    {
        public CreateStartupDto Startup { get; set; } = null!;
    }
}
