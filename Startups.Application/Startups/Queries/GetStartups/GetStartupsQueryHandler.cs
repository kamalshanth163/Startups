using AutoMapper;
using MediatR;
using Startups.Application.Startups.Dtos;
using Startups.Domain.Repositories;

namespace Startups.Application.Startups.Queries.GetStartups
{
    public class GetStartupsQueryHandler : IRequestHandler<GetStartupsQuery, List<StartupDto>>
    {
        private readonly IStartupRepository _startupRepository;
        private readonly IMapper _mapper;

        public GetStartupsQueryHandler(IStartupRepository startupRepository, IMapper mapper)
        {
            _startupRepository = startupRepository;
            _mapper = mapper;
        }

        public async Task<List<StartupDto>> Handle(GetStartupsQuery request, CancellationToken cancellationToken)
        {
            // Gets all the startups
            var startups = await _startupRepository.GetAllAsync();

            // Maps to startup models to DTOs
            var startupDtos = _mapper.Map<List<StartupDto>>(startups);

            // Returns the mapped startup DTOs
            return startupDtos;
        }
    }
}
