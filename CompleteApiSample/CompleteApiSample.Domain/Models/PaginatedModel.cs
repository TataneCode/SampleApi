using CompleteApiSample.Domain.Entities;

namespace CompleteApiSample.Domain.Models
{
    public class PaginatedModel<TEntity> where TEntity : BaseEntity
    {
        public ICollection<TEntity> PaginatedEntities { get; set; } = Array.Empty<TEntity>();

        public int TotalCount { get; set; }
    }
}
