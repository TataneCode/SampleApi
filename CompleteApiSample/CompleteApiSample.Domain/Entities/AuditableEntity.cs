using CompleteApiSample.Domain.Entities.Interfaces;

namespace CompleteApiSample.Domain.Entities
{
    public abstract class AuditableEntity : BaseEntity, IAuditable
    {
        public string UserName { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
    }
}
