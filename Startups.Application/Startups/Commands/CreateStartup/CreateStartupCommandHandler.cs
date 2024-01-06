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
        private readonly IFounderRepository _founderRepository;
        private readonly IMapper _mapper;

        public CreateStartupCommandHandler(IStartupRepository startupRepository, IFounderRepository founderRepository, IMapper mapper)
        {
            _startupRepository = startupRepository;
            _founderRepository = founderRepository;
            _mapper = mapper;
        }

        public async Task<StartupDto> Handle(CreateStartupCommand request, CancellationToken cancellationToken)
        {
            // Gets a founder using id
            var founder = await _founderRepository.GetByIdAsync(request.Startup.FounderId);

            // Maps startup model to limit accessiblities of properties
            var newStartup = _mapper.Map<Startup>(request.Startup);

            // Assigns the retrieved founder to the new startup
            newStartup.Founder = founder;

            // Creates a new startup from repository
            var createdStartup = await _startupRepository.CreateAsync(newStartup);

            // Maps and returns created startup model
            var startupDto = _mapper.Map<StartupDto>(createdStartup);
            return startupDto;
        }
    }
}
