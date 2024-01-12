using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CompleteApiSample.Common.Exceptions
{
    [ExcludeFromCodeCoverage, Serializable]
    public class RepositoryException : LibraryException
    {
        public RepositoryException(string message) : base(message)
        {

        }

        public RepositoryException(string message, Exception innerException) : base(message, innerException)
        {

        }

        protected RepositoryException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {

        }
    }
}
