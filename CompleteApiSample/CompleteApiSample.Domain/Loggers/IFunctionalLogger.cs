using Microsoft.Extensions.Logging;

namespace CompleteApiSample.Domain.Provider
{
    public interface IFunctionalLogger
    {
        ILogger Logger { get; }
    }
}
