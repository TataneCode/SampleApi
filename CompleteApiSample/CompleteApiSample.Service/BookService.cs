using CompleteApiSample.Common.Constants;
using CompleteApiSample.Domain.Entities;
using CompleteApiSample.Domain.Provider;
using CompleteApiSample.Domain.Repositories;
using CompleteApiSample.Domain.Services;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CompleteApiSample.Service
{
    public class BookService : BaseService<Book, IBookRepository>, IBookService
    {
        private readonly IFunctionalLogger _functionalLogger;

        public BookService(
            IBookRepository repository,
            ILogger<Book> logger,
            IFunctionalLogger functionalLogger) : base(repository, logger)
        {
            _functionalLogger = functionalLogger;
        }

        public override async Task<Book> CreateAsync(Book entity)
        {
            var book = await base.CreateAsync(entity);
            _functionalLogger.Logger.LogInformation("book with id={id} and title={title} was added by user={user}.", book.Id, book.Title, book.UserName);
            TelemetryMeter.BookAddingCounter.Add(1, new TagList { { TelemetryKey.Username, book.UserName } });

            return book;
        }
    }
}
