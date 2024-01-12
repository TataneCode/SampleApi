using CompleteApiSample.Domain.Entities;
using CompleteApiSample.Domain.Models;
using CompleteApiSample.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CompleteApiSample.Infrastructure.Repositories
{
    public abstract class BaseAuditableRepository<TAuditableEntity> : IAuditableRepository<TAuditableEntity>
        where TAuditableEntity : AuditableEntity
    {
        protected readonly LibraryDbContext _dbContext;
        protected readonly ILogger<TAuditableEntity> _logger;

        protected BaseAuditableRepository(
            LibraryDbContext dbContext,
            ILogger<TAuditableEntity> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public virtual void Add(TAuditableEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            entity.UserName = "Admin";

            _dbContext.Add(entity);
        }

        public virtual void Delete(TAuditableEntity entity)
        {
            _dbContext.Remove(entity);
        }

        public virtual async Task<TAuditableEntity?> GetAsync(long id)
        {
            return await _dbContext.Set<TAuditableEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<PaginatedModel<TAuditableEntity>> GetPaginatedAsync(int pageNumber, int pageSize)
        {
            var model = new PaginatedModel<TAuditableEntity>
            {
                PaginatedEntities = await
                _dbContext.Set<TAuditableEntity>()
                .OrderBy(b => b.Id)
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToListAsync(),
                TotalCount = await _dbContext.Set<TAuditableEntity>().CountAsync()
            };

            return model;
        }

        public virtual void Update(TAuditableEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            entity.UserName = "Admin";

            _dbContext.Update(entity);
        }

        public virtual async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
