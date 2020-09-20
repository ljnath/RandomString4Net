using System;
using System.Runtime.Serialization;

namespace RandomString4Net.Exceptions
{
    [Serializable]
    public class UnsupportedSymbolException : Exception
    {
        public UnsupportedSymbolException() : base() { }

        public UnsupportedSymbolException(string message) : base(message) { }

        public UnsupportedSymbolException(string format, params object[] args) : base(string.Format(format, args)) { }

        public UnsupportedSymbolException(string message, Exception innerException) : base(message, innerException) { }

        public UnsupportedSymbolException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }

        protected UnsupportedSymbolException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
