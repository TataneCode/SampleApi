using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CompleteApiSample.Common.Exceptions
{
    [ExcludeFromCodeCoverage, Serializable]
    public class ServiceException : LibraryException
    {
        public ServiceException(string message) : base(message)
        {

        }

        public ServiceException(string message, Exception innerException) : base(message, innerException)
        {

        }

        protected ServiceException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {

        }
    }
}
