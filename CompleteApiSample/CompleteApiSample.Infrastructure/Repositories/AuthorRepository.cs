using CompleteApiSample.Domain.Entities;
using CompleteApiSample.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CompleteApiSample.Infrastructure.Repositories
{
    public class AuthorRepository : BaseAuditableRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(
            LibraryDbContext dbContext,
            ILogger<Author> logger) : base(dbContext, logger)
        {
        }
    }
}
