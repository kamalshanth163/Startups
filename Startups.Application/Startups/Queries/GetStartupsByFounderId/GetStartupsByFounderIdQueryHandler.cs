using AutoMapper;
using MediatR;
using Startups.Application.Startups.Dtos;
using Startups.Domain.Repositories;

namespace Startups.Application.Startups.Queries.GetStartupById
{
    public class GetStartupsByFounderIdQueryHandler : IRequestHandler<GetStartupsByFounderIdQuery, List<StartupDto>>
    {
        private readonly IStartupRepository _startupRepository;
        private readonly IMapper _mapper;

        public GetStartupsByFounderIdQueryHandler(IStartupRepository startupRepository, IMapper mapper)
        {
            _startupRepository = startupRepository;
            _mapper = mapper;
        }

        public async Task<List<StartupDto>> Handle(GetStartupsByFounderIdQuery request, CancellationToken cancellationToken)
        {
            // Gets startups of a specific founder using founderId
            var startups = await _startupRepository.GetByFounderIdAsync(request.FounderId);

            // Maps the startups to DTOs
            var startupDtos = _mapper.Map<List<StartupDto>>(startups);

            // Returns the mapped startup DTOs
            return startupDtos;
        }
    }
}
