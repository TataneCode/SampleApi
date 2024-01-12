using CompleteApiSample.Domain.Entities;
using CompleteApiSample.Domain.Provider;
using CompleteApiSample.Domain.Repositories;
using CompleteApiSample.Infrastructure.Loggers;
using CompleteApiSample.Service;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CompleteApiSample.Test.Services
{
    public class AuthorServiceTest
    {
        private readonly Mock<IAuthorRepository> _repositoryMock;
        private readonly Mock<ILogger<Author>> _loggerMock;
        private readonly Mock<IFunctionalLogger> _functionalLoggerMock;

        public AuthorServiceTest()
        {
            _repositoryMock = new Mock<IAuthorRepository>();
            _loggerMock = new Mock<ILogger<Author>>();
            _functionalLoggerMock = new Mock<IFunctionalLogger>();
            var functionalLoggerImplementationMock = new Mock<ILogger<FunctionalLogger>>();
            _functionalLoggerMock.SetupGet(x => x.Logger).Returns(functionalLoggerImplementationMock.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var expected = new { FirstName = "Stefen", };
            var service = new AuthorService(_repositoryMock.Object, _loggerMock.Object, _functionalLoggerMock.Object);

            // Act
            await service.CreateAsync(new Author { FirstName = "Stefen", LastName = "Kong", });

            // Assert
            _repositoryMock.Verify(x => x.Add(It.Is<Author>(a => expected.FirstName == a.FirstName)), Times.Once);
            _repositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}
