using CompleteApiSample.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace CompleteApiSample.Test.Repositories
{
    public abstract class BaseRepositoryTest<TEntity>
    {
        protected readonly LibraryDbContext _dbContext;
        protected readonly Mock<ILogger<TEntity>> _loggerMock;

        protected BaseRepositoryTest()
        {
            _dbContext = new LibraryDbContext(
                new DbContextOptionsBuilder<LibraryDbContext>()
                .EnableSensitiveDataLogging(true)
                .UseInMemoryDatabase("library")
                .Options);
            _loggerMock = new Mock<ILogger<TEntity>>();
        }
    }
}
