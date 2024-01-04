using MediatR;

namespace Startups.Application.Startups.Commands.DeleteStartup
{
    public class DeleteStartupCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
