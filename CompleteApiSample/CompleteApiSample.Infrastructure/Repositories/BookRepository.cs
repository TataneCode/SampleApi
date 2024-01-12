using CompleteApiSample.Domain.Entities;
using CompleteApiSample.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CompleteApiSample.Infrastructure.Repositories
{
    public class BookRepository : BaseAuditableRepository<Book>, IBookRepository
    {
        public BookRepository(
            LibraryDbContext dbContext,
            ILogger<Book> logger) : base(dbContext, logger)
        {
        }
    }
}
