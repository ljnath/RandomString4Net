using System;
using System.Runtime.Serialization;

namespace RandomString4Net.Exceptions
{
    [Serializable]
    public class InvalidLengthException : Exception
    {
        public InvalidLengthException() : base() { }

        public InvalidLengthException(string message) : base(message) { }

        public InvalidLengthException(string format, params object[] args) : base(string.Format(format, args)) { }

        public InvalidLengthException(string message, Exception innerException) : base(message, innerException) { }

        public InvalidLengthException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }

        protected InvalidLengthException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
