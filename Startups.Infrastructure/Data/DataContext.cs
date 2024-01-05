using Microsoft.EntityFrameworkCore;
using Startups.Domain.Entities;

namespace Startups.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Founder> Founders { get; set; }
        public DbSet<Startup> Startups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Startup>()
                .HasOne(b => b.Founder)
                .WithMany(c => c.Startups)
                .HasForeignKey(b => b.FounderId);

            modelBuilder.Entity<Founder>()
                .HasMany(c => c.Startups)
                .WithOne(b => b.Founder)
                .HasForeignKey(b => b.FounderId);
        }
    }
}

