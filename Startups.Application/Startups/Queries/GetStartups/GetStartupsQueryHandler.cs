using AutoMapper;
using MediatR;
using Startups.Application.Startups.Dtos;
using Startups.Domain.Repositories;

namespace Startups.Application.Startups.Queries.GetStartups
{
    public class GetStartupByIdQueryHandler : IRequestHandler<GetStartupByIdQuery, List<StartupDto>>
    {
        private readonly IStartupRepository _startupRepository;
        private readonly IMapper _mapper;

        public GetStartupByIdQueryHandler(IStartupRepository startupRepository, IMapper mapper)
        {
            _startupRepository = startupRepository;
            _mapper = mapper;
        }

        public async Task<List<StartupDto>> Handle(GetStartupByIdQuery request, CancellationToken cancellationToken)
        {
            var startups = await _startupRepository.GetAllAsync();
            var startupDtos = _mapper.Map<List<StartupDto>>(startups);
            return startupDtos;
        }
    }
}
