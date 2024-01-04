using AutoMapper;
using MediatR;
using Startups.Application.Startups.Dtos;
using Startups.Domain.Repositories;

namespace Startups.Application.Startups.Queries.GetStartupById
{
    public class CreateStartupCommandHandler : IRequestHandler<GetStartupByIdQuery, StartupDto>
    {
        private readonly IStartupRepository _startupRepository;
        private readonly IMapper _mapper;

        public CreateStartupCommandHandler(IStartupRepository startupRepository, IMapper mapper)
        {
            _startupRepository = startupRepository;
            _mapper = mapper;
        }

        public async Task<StartupDto> Handle(GetStartupByIdQuery request, CancellationToken cancellationToken)
        {
            var startup = await _startupRepository.GetByIdAsync(request.Id);
            var startupDto = _mapper.Map<StartupDto>(startup);
            return startupDto;
        }
    }
}
