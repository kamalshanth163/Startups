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
            // Retrieves a founder using id from repository
            var founder = await _founderRepository.GetByIdAsync(request.Startup.FounderId);

            // Maps 'data transfer object' to startup class
            var existingStartup = _mapper.Map<Startup>(request.Startup);

            // Assigns retrieved founder and the updated date to the existing startup data
            existingStartup.Founder = founder;
            existingStartup.Updated = DateTimeOffset.UtcNow;

            // Sends the customized startup to update
            var updatedStartup = await _startupRepository.UpdateAsync(request.Startup.Id, existingStartup);

            // Maps and returns the startup model with needed information
            var startupDto = _mapper.Map<StartupDto>(updatedStartup);
            return startupDto;
        }
    }
}
