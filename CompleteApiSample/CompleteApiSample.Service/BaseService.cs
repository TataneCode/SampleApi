using CompleteApiSample.Common.Exceptions;
using CompleteApiSample.Domain.Entities;
using CompleteApiSample.Domain.Models;
using CompleteApiSample.Domain.Repositories;
using CompleteApiSample.Domain.Services;
using Microsoft.Extensions.Logging;

namespace CompleteApiSample.Service
{
    public abstract class BaseService<TAuditableEntity, TRepository> : IBaseService<TAuditableEntity>
        where TAuditableEntity : AuditableEntity
        where TRepository : IAuditableRepository<TAuditableEntity>
    {

        protected readonly TRepository _repository;
        private readonly ILogger<TAuditableEntity> _logger;

        protected BaseService(
            TRepository repository,
            ILogger<TAuditableEntity> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public virtual async Task<TAuditableEntity> CreateAsync(TAuditableEntity entity)
        {
            _repository.Add(entity);
            await _repository.SaveChangesAsync();

            return entity;
        }

        public virtual async Task DeleteAsync(long id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
            {
                _logger.LogError($"{nameof(DeleteAsync)} : No {{entity}} with id {{id}} was found.", nameof(TAuditableEntity), id);
                throw new ServiceException($"{id} does not exists !");
            }

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }

        public virtual async Task<PaginatedModel<TAuditableEntity>> GetAllPaginatedAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPaginatedAsync(pageNumber, pageSize);
        }

        public virtual async Task<TAuditableEntity?> GetAsync(long id)
        {
            return await _repository.GetAsync(id);
        }

        public virtual async Task UpdateAsync(TAuditableEntity entity)
        {
            var entityToUpdate = await _repository.GetAsync(entity.Id);
            if (entityToUpdate == null)
            {
                _logger.LogError($"{nameof(UpdateAsync)} : No {{entity}} with id {{id}} was found.", nameof(TAuditableEntity), entity.Id);
                throw new ServiceException($"{entity.Id} does not exists !");
            }

            _repository.Update(entity);
            await _repository.SaveChangesAsync();
        }
    }
}
