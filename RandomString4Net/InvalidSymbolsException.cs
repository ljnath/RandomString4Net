using System;
using System.Runtime.Serialization;

namespace RandomString4Net
{
    [Serializable]
    public class InvalidSymbolsException : Exception
    {
        public InvalidSymbolsException() : base() { }

        public InvalidSymbolsException(string message) : base(message) { }

        public InvalidSymbolsException(string format, params object[] args) : base(string.Format(format, args)) { }

        public InvalidSymbolsException(string message, Exception innerException) : base(message, innerException) { }

        public InvalidSymbolsException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }

        protected InvalidSymbolsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
