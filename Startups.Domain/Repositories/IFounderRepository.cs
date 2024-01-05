using Startups.Domain.Entities;

namespace Startups.Domain.Repositories
{
    public interface IFounderRepository
    {
        Task<Founder> GetByIdAsync(Guid id);
        Task<Founder> GetByEmailAsync(string email);
        Task<Founder> RegisterAsync(Founder founder);
    }
}
