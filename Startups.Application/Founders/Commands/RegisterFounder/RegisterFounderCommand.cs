using MediatR;
using Startups.Application.Founders.Dtos;

namespace Startups.Application.Founders.Commands.RegisterFounder
{
    public class RegisterFounderCommand : IRequest<FounderDto>
    {
        public RegisterFounderDto Founder { get; set; } = null!;

        public RegisterFounderCommand(RegisterFounderDto founder)
        {
            Founder = founder;
        }
    }
}
