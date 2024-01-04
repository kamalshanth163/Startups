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
        private readonly IMapper _mapper;

        public UpdateStartupCommandHandler(IStartupRepository startupRepository, IMapper mapper)
        {
            _startupRepository = startupRepository;
            _mapper = mapper;
        }

        public async Task<StartupDto> Handle(UpdateStartupCommand request, CancellationToken cancellationToken)
        {
            var existingStartup = _mapper.Map<Startup>(request.Startup);
            var updatedStartup = await _startupRepository.UpdateAsync(request.Id, existingStartup);
            var startupDto = _mapper.Map<StartupDto>(updatedStartup);
            return startupDto;
        }
    }
}
