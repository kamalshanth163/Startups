using MediatR;
using Startups.Domain.Repositories;

namespace Startups.Application.Startups.Commands.DeleteStartup
{
    public class DeleteStartupCommandHandler : IRequestHandler<DeleteStartupCommand, Guid>
    {
        private readonly IStartupRepository _startupRepository;

        public DeleteStartupCommandHandler(IStartupRepository startupRepository)
        {
            _startupRepository = startupRepository;
        }

        public async Task<Guid> Handle(DeleteStartupCommand request, CancellationToken cancellationToken)
        {
            // Deletes startup using it's unique identifier (id)
            var deletedStartupId = await _startupRepository.DeleteAsync(request.Id);

            // Returns the id of the deleted record
            return deletedStartupId;
        }
    }
}
