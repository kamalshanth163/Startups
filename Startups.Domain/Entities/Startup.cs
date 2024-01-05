using System.ComponentModel.DataAnnotations;

namespace Startups.Domain.Entities
{
    public class Startup : BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string BusinessDomain { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal GrossSales { get; set; } = 0;
        public decimal NetSales { get; set; } = 0;
        public DateTimeOffset BusinessStartDate { get; set; }
        public string Website { get; set; } = null!;
        public string BusinessLocation { get; set; } = null!;
        public int EmployeeCount { get; set; } = 0;

        public Guid FounderId { get; set; }
        public Founder Founder { get; set; } = null!;


        public Startup () { }

        public Startup(
            string businessDomain,
            string description,
            decimal grossSales,
            decimal netSales,
            DateTimeOffset businessStartDate,
            string website,
            string businessLocation,
            int employeeCount,
            Founder founder
        )
        {
            BusinessDomain = businessDomain;
            Description = description;
            GrossSales = grossSales;
            NetSales = netSales;
            BusinessStartDate = businessStartDate;
            Website = website;
            BusinessLocation = businessLocation;
            EmployeeCount = employeeCount;
            FounderId = founder.Id;
            Founder = founder;
        }
    }
}