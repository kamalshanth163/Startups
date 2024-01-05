using MediatR;
using Startups.Application.Startups.Dtos;

namespace Startups.Application.Startups.Queries.GetStartups
{
    public class GetStartupsQuery : IRequest<List<StartupDto>>
    {
    }
}
