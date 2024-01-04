namespace Startups.Domain.Entities
{
    public class Founder : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;

        public ICollection<Startup> Startups { get; set; } = null!;

    }
}

