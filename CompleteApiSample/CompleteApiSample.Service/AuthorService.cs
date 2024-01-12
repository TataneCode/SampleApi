using CompleteApiSample.Common.Constants;
using CompleteApiSample.Domain.Entities;
using CompleteApiSample.Domain.Provider;
using CompleteApiSample.Domain.Repositories;
using CompleteApiSample.Domain.Services;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CompleteApiSample.Service
{
    public class AuthorService : BaseService<Author, IAuthorRepository>, IAuthorService
    {
        private readonly IFunctionalLogger _functionalLogger;

        public AuthorService(
            IAuthorRepository repository,
            ILogger<Author> logger,
            IFunctionalLogger functionalLogger) : base(repository, logger)
        {
            _functionalLogger = functionalLogger;
        }

        public override async Task<Author> CreateAsync(Author entity)
        {
            var author = await base.CreateAsync(entity);
            _functionalLogger.Logger.LogInformation("Author with id={id} and name={name} was added by user={user}.", author.Id, author.LastName, author.UserName);
            TelemetryMeter.AuthorAddingCounter.Add(1, new TagList { { TelemetryKey.Username, author.UserName } });

            return author;
        }
    }
}
