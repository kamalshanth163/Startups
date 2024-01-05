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
            var startups = await _startupRepository.GetByFounderIdAsync(request.FounderId);
            var startupDtos = _mapper.Map<List<StartupDto>>(startups);
            return startupDtos;
        }
    }
}
