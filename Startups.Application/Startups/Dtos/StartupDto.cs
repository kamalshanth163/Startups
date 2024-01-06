using Startups.Application.Common.Mappings;
using Startups.Domain.Entities;

namespace Startups.Application.Startups.Dtos
{
    public class StartupDto : IMapFrom<Startup>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string BusinessDomain { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal GrossSales { get; set; } = 0;
        public decimal NetSales { get; set; } = 0;
        public DateTimeOffset BusinessStartDate { get; set; }
        public string Website { get; set; } = null!;
        public string BusinessLocation { get; set; } = null!;
        public int EmployeeCount { get; set; } = 0;
        public string FounderName { get; set; } = null!;
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
}
