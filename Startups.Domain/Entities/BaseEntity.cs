namespace Startups.Domain.Entities
{
    public abstract class BaseEntity
    {
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset Updated { get; set; } = DateTimeOffset.UtcNow;
    }
}
