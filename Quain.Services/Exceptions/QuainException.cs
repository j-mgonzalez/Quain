namespace Quain.Services.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class QuainException : Exception
    {
        public QuainException()
        {
        }

        public QuainException(string message) : base(message)
        {
        }

        public QuainException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QuainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}