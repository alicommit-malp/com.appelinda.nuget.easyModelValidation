using System;
using System.Runtime.Serialization;

namespace EasyModelValidator
{
    public class ModelValidationException : Exception
    {
        public ModelValidationException()
        {
        }

        protected ModelValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ModelValidationException(string message) : base(message)
        {
        }

        public ModelValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}