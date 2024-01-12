using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CompleteApiSample.Common.Exceptions
{
    [ExcludeFromCodeCoverage, Serializable]
    public class LibraryException : Exception
    {
        public LibraryException()
        {

        }

        public LibraryException(string message) : base(message)
        {

        }

        public LibraryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LibraryException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {

        }
    }
}
