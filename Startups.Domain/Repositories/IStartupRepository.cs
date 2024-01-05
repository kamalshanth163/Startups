using Startups.Domain.Entities;

namespace Startups.Domain.Repositories
{
    public interface IStartupRepository
    {
        Task<List<Startup>> GetAllAsync();
        Task<Startup> GetByIdAsync(Guid id);
        Task<List<Startup>> GetByFounderIdAsync(Guid founderId);
        Task<Startup> CreateAsync(Startup startup);
        Task<Startup> UpdateAsync(Guid id, Startup startup);
        Task<Guid> DeleteAsync(Guid id);
    }
}
