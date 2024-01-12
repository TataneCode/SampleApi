using CompleteApiSample.Domain.Entities;
using CompleteApiSample.Domain.Models;

namespace CompleteApiSample.Domain.Services
{
    public interface IBaseService<TAuditableEntity>
        where TAuditableEntity : AuditableEntity
    {
        Task<TAuditableEntity> CreateAsync(TAuditableEntity entity);

        Task UpdateAsync(TAuditableEntity entity);

        Task DeleteAsync(long id);

        Task<TAuditableEntity?> GetAsync(long id);

        Task<PaginatedModel<TAuditableEntity>> GetAllPaginatedAsync(int pageNumber, int pageSize);
    }
}
