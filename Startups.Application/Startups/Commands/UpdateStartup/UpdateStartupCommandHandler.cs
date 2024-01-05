using AutoMapper;
using MediatR;
using Startups.Application.Startups.Dtos;
using Startups.Domain.Entities;
using Startups.Domain.Repositories;

namespace Startups.Application.Startups.Commands.UpdateStartup
{
    public class UpdateStartupCommandHandler : IRequestHandler<UpdateStartupCommand, StartupDto>
    {
        private readonly IStartupRepository _startupRepository;
        private readonly IFounderRepository _founderRepository;
        private readonly IMapper _mapper;

        public UpdateStartupCommandHandler(IStartupRepository startupRepository, IFounderRepository founderRepository, IMapper mapper)
        {
            _startupRepository = startupRepository;
            _founderRepository = founderRepository;
            _mapper = mapper;
        }

        public async Task<StartupDto> Handle(UpdateStartupCommand request, CancellationToken cancellationToken)
        {
            var founder = await _founderRepository.GetByIdAsync(request.Startup.FounderId);

            var existingStartup = _mapper.Map<Startup>(request.Startup);
            existingStartup.Founder = founder;
            existingStartup.Updated = DateTimeOffset.UtcNow;

            var updatedStartup = await _startupRepository.UpdateAsync(request.Startup.Id, existingStartup);
            var startupDto = _mapper.Map<StartupDto>(updatedStartup);

            return startupDto;
        }
    }
}
