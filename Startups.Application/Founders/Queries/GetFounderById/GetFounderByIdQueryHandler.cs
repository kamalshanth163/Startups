using AutoMapper;
using MediatR;
using Startups.Application.Founders.Dtos;
using Startups.Domain.Repositories;

namespace Startups.Application.Founders.Queries.GetFounderById
{
    public class GetFounderByIdQueryHandler : IRequestHandler<GetFounderByIdQuery, FounderDto>
    {
        private readonly IFounderRepository _founderRepository;
        private readonly IMapper _mapper;

        public GetFounderByIdQueryHandler(IFounderRepository founderRepository, IMapper mapper)
        {
            _founderRepository = founderRepository;
            _mapper = mapper;
        }

        public async Task<FounderDto> Handle(GetFounderByIdQuery request, CancellationToken cancellationToken)
        {
            // Retrieves founder by id
            var founder = await _founderRepository.GetByIdAsync(request.Id);

            // Maps the foudner model to founer DTO
            var founderDto = _mapper.Map<FounderDto>(founder);

            // Returns the mapped founder DTO
            return founderDto;
        }
    }
}
