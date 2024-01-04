using MediatR;
using Startups.Application.Startups.Dtos;

namespace Startups.Application.Startups.Queries.GetStartups
{
    public class GetStartupByIdQuery : IRequest<List<StartupDto>>
    {
    }
}
