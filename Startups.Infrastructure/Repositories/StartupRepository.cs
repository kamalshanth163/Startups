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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Creates a new startup.
        /// </summary>
        /// <param name="startup">The startup entity to be created.</param>
        /// <returns>Returns the created startup.</returns>
        public async Task<Startup> CreateAsync(Startup startup)
        {
            await _context.Startups.AddAsync(startup);
            await _context.SaveChangesAsync();
            return startup;
        }

        /// <summary>
        /// Deletes a startup by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the startup.</param>
        /// <returns>Returns the ID of the deleted startup.</returns>
        public async Task<Guid> DeleteAsync(Guid id)
        {
            await _context.Startups.Where(s => s.Id == id).ExecuteDeleteAsync();
            return id;
        }

        /// <summary>
        /// Retrieves all startups.
        /// </summary>
        /// <returns>Returns a list of all startups.</returns>
        public async Task<List<Startup>> GetAllAsync()
        {
            return await _context.Startups.Include(s => s.Founder).ToListAsync();
        }

        /// <summary>
        /// Retrieves a startup by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the startup.</param>
        /// <returns>Returns a startup entity if found, otherwise null.</returns>
        public async Task<Startup> GetByIdAsync(Guid id)
        {
            return await _context.Startups.Include(s => s.Founder).SingleOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// Retrieves startups by founder ID.
        /// </summary>
        /// <param name="founderId">The founder ID.</param>
        /// <returns>Returns a list of startups associated with the given founder.</returns>
        public async Task<List<Startup>> GetByFounderIdAsync(Guid founderId)
        {
            return await _context.Startups.Include(s => s.Founder).Where(s => s.FounderId == founderId).ToListAsync();
        }

        /// <summary>
        /// Updates a startup entity.
        /// </summary>
        /// <param name="id">The unique identifier of the startup to be updated.</param>
        /// <param name="startup">The updated startup entity.</param>
        /// <returns>Returns the updated startup entity if found, otherwise the input startup.</returns>
        public async Task<Startup> UpdateAsync(Guid id, Startup startup)
        {
            var existingStartup = await _context.Startups.SingleOrDefaultAsync(s => s.Id == id);

            if (existingStartup != null)
            {
                // Updates the properties of the existing startup entity
                existingStartup.Name = startup.Name;
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

            // If the existing startup is null, returns the input startup
            return existingStartup ?? startup;
        }
    }
}
