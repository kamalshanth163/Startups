using MediatR;
using Startups.Application.Founders.Dtos;

namespace Startups.Application.Founders.Queries.LoginFounder
{
    public class LoginFounderQuery : IRequest<FounderDto>
    {
        public LoginFounderDto Founder { get; set; } = null!;

        public LoginFounderQuery(LoginFounderDto founder)
        {
            Founder = founder;
        }
    }
}
