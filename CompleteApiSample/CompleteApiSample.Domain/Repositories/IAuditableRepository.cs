using CompleteApiSample.Domain.Entities;
using CompleteApiSample.Domain.Models;

namespace CompleteApiSample.Domain.Repositories
{
    public interface IAuditableRepository<TAuditableEntity>
        where TAuditableEntity : AuditableEntity
    {
        Task<TAuditableEntity?> GetAsync(long id);

        Task<PaginatedModel<TAuditableEntity>> GetPaginatedAsync(int pageNumber, int pageSize);

        void Update(TAuditableEntity entity);

        void Add(TAuditableEntity entity);

        void Delete(TAuditableEntity entity);

        Task SaveChangesAsync();
    }
}
