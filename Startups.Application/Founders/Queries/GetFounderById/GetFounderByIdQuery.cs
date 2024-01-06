using MediatR;
using Startups.Application.Founders.Dtos;

namespace Startups.Application.Founders.Queries.GetFounderById
{
    public class GetFounderByIdQuery : IRequest<FounderDto>
    {
        public Guid Id { get; set; }

        public GetFounderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
