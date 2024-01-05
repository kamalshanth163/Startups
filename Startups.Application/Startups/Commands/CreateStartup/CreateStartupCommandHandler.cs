using AutoMapper;
using MediatR;
using Startups.Application.Startups.Dtos;
using Startups.Domain.Entities;
using Startups.Domain.Repositories;

namespace Startups.Application.Startups.Commands.CreateStartup
{
    public class CreateStartupCommandHandler : IRequestHandler<CreateStartupCommand, StartupDto>
    {
        private readonly IStartupRepository _startupRepository;
        private readonly IMapper _mapper;

        public CreateStartupCommandHandler(IStartupRepository startupRepository, IMapper mapper)
        {
            _startupRepository = startupRepository;
            _mapper = mapper;
        }

        public async Task<StartupDto> Handle(CreateStartupCommand request, CancellationToken cancellationToken)
        {
            var newStartup = _mapper.Map<Startup>(request.Startup);
            var createdStartup = await _startupRepository.CreateAsync(newStartup);
            var startupDto = _mapper.Map<StartupDto>(createdStartup);
            return startupDto;
        }
    }
}
