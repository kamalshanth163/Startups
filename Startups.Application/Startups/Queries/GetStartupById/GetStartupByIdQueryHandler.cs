using AutoMapper;
using MediatR;
using Startups.Application.Startups.Dtos;
using Startups.Domain.Repositories;

namespace Startups.Application.Startups.Queries.GetStartupById
{
    public class GetStartupByIdQueryHandler : IRequestHandler<GetStartupByIdQuery, StartupDto>
    {
        private readonly IStartupRepository _startupRepository;
        private readonly IMapper _mapper;

        public GetStartupByIdQueryHandler(IStartupRepository startupRepository, IMapper mapper)
        {
            _startupRepository = startupRepository;
            _mapper = mapper;
        }

        public async Task<StartupDto> Handle(GetStartupByIdQuery request, CancellationToken cancellationToken)
        {
            // Gets starup by id from repository
            var startup = await _startupRepository.GetByIdAsync(request.Id);

            // Maps to limit accessible properties
            var startupDto = _mapper.Map<StartupDto>(startup);

            // Returns the mapped startup DTO
            return startupDto;
        }
    }
}
