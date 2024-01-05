using Microsoft.EntityFrameworkCore;
using Startups.Domain.Entities;
using Startups.Domain.Repositories;
using Startups.Infrastructure.Data;

namespace Startups.Infrastructure.Repositories
{
    public class FounderRepository : IFounderRepository
    {
        private readonly DataContext _context;

        public FounderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Founder> GetByIdAsync(Guid id)
        {
            return await _context.Founders.SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Founder> GetByEmailAsync(string email)
        {
            var existingFounder = await _context.Founders.SingleOrDefaultAsync(f => f.Email == email);
            return existingFounder!;
        }

        public async Task<Founder> RegisterAsync(Founder founder)
        {
            await _context.Founders.AddAsync(founder);
            await _context.SaveChangesAsync();
            return founder;
        }

    }
}
