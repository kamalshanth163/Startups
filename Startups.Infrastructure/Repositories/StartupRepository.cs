using Microsoft.EntityFrameworkCore;
using Startups.Domain.Entities;
using Startups.Domain.Repositories;
using Startups.Infrastructure.Data;

namespace Startups.Infrastructure.Repositories
{
    public class StartupRepository : IStartupRepository
    {
        private readonly DataContext _context;

        public StartupRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Startup> CreateAsync(Startup startup)
        {
            await _context.Startups.AddAsync(startup);
            await _context.SaveChangesAsync();
            return startup;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            await _context.Startups.Where(s => s.Id == id).ExecuteDeleteAsync();
            return id;
        }

        public async Task<List<Startup>> GetAllAsync()
        {
            return await _context.Startups.Include(s => s.Founder).ToListAsync();
        }

        public async Task<Startup> GetByIdAsync(Guid id)
        {
            return await _context.Startups.Include(s => s.Founder).SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Startup>> GetByFounderIdAsync(Guid founderId)
        {
            return await _context.Startups.Include(s => s.Founder).Where(s => s.FounderId == founderId).ToListAsync();
        }

        public async Task<Startup> UpdateAsync(Guid id, Startup startup)
        {
            var existingStartup = await _context.Startups.SingleOrDefaultAsync(s => s.Id == id);

            if (existingStartup != null)
            {
                existingStartup.BusinessDomain = startup.BusinessDomain;
                existingStartup.Description = startup.Description;
                existingStartup.GrossSales = startup.GrossSales;
                existingStartup.NetSales = startup.NetSales;
                existingStartup.BusinessStartDate = startup.BusinessStartDate;
                existingStartup.Website = startup.Website;
                existingStartup.BusinessLocation = startup.BusinessLocation;
                existingStartup.EmployeeCount = startup.EmployeeCount;
                existingStartup.FounderId = startup.FounderId;
                existingStartup.Founder = startup.Founder;
                existingStartup.Created = startup.Created;
                existingStartup.Updated = startup.Updated;

                await _context.SaveChangesAsync();
            }

            return existingStartup ?? startup;
        }
    }
}
