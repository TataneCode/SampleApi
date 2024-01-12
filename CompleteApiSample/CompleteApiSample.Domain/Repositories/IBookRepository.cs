using CompleteApiSample.Domain.Entities;

namespace CompleteApiSample.Domain.Repositories
{
    public interface IBookRepository : IAuditableRepository<Book>
    {
    }
}
