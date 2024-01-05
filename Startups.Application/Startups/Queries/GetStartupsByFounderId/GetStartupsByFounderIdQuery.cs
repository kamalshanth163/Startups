using MediatR;
using Startups.Application.Startups.Dtos;

namespace Startups.Application.Startups.Queries.GetStartupById
{
    public class GetStartupsByFounderIdQuery : IRequest<List<StartupDto>>
    {
        public Guid FounderId { get; set; }

        public GetStartupsByFounderIdQuery(Guid founderId)
        {
            FounderId = founderId;
        }
    }
}
