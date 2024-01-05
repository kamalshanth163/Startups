using MediatR;
using Startups.Application.Startups.Dtos;

namespace Startups.Application.Startups.Queries.GetStartupById
{
    public class GetStartupByIdQuery : IRequest<StartupDto>
    {
        public Guid Id { get; set; }
    }
}
