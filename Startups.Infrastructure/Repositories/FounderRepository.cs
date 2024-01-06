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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Retrieves a founder by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the founder.</param>
        /// <returns>Returns a founder entity if found, otherwise null.</returns>
        public async Task<Founder> GetByIdAsync(Guid id)
        {
            return await _context.Founders.SingleOrDefaultAsync(f => f.Id == id);
        }

        /// <summary>
        /// Retrieves a founder by their email address.
        /// </summary>
        /// <param name="email">The email address of the founder.</param>
        /// <returns>Returns a founder entity if found, otherwise null.</returns>
        public async Task<Founder> GetByEmailAsync(string email)
        {
            return await _context.Founders.SingleOrDefaultAsync(f => f.Email == email);
        }

        /// <summary>
        /// Registers a new founder.
        /// </summary>
        /// <param name="founder">The founder entity to be registered.</param>
        /// <returns>Returns the registered founder.</returns>
        public async Task<Founder> RegisterAsync(Founder founder)
        {
            await _context.Founders.AddAsync(founder);
            await _context.SaveChangesAsync();
            return founder;
        }
    }
}
