namespace Startups.Domain.Entities
{
    public abstract class BaseEntity
    {
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
}
