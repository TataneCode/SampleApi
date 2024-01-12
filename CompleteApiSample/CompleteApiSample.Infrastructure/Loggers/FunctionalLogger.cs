using CompleteApiSample.Domain.Provider;
using Microsoft.Extensions.Logging;

namespace CompleteApiSample.Infrastructure.Loggers
{
    public class FunctionalLogger : IFunctionalLogger
    {
        public ILogger Logger { get { return _logger; } }
        private readonly ILogger _logger;

        public FunctionalLogger(ILogger<FunctionalLogger> logger)
        {
            _logger = logger;
        }
    }
}
