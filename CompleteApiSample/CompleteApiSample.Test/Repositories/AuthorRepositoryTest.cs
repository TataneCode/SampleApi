using CompleteApiSample.Domain.Entities;
using CompleteApiSample.Infrastructure.Repositories;
using Xunit;

namespace CompleteApiSample.Test.Repositories
{
    public class AuthorRepositoryTest : BaseRepositoryTest<Author>
    {
        [Fact]
        public async Task GetPaginatedAsync()
        {
            // Arrange
            var expected = new { FirstName = "Stefen", TotalCount = 2, Count = 1, };
            _dbContext.AddRange(new List<Author>
            {
                new()
                {
                    FirstName = "Stefen",
                    LastName = "Kong",
                    UserName = "Admin",
                    UpdatedAt = DateTime.UtcNow,
                },
                new()
                {
                    FirstName = "Gustaff",
                    LastName = "Vlaubert",
                    UserName = "Admin",
                    UpdatedAt = DateTime.UtcNow,
                },
            });
            await _dbContext.SaveChangesAsync();
            var repository = new AuthorRepository(_dbContext, _loggerMock.Object);

            // Act
            var result = await repository.GetPaginatedAsync(0, 1);

            // Assert
            Assert.Equal(expected.TotalCount, result.TotalCount);
            Assert.Equal(expected.Count, result.PaginatedEntities.Count);
            Assert.Equal(expected.FirstName, result.PaginatedEntities.First().FirstName);
        }
    }
}
