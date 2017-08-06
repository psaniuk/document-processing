using System;
using System.Runtime.Serialization;

namespace Motosoft.DocumentProcessing.App.Exceptions
{
    public class DocumentCountException: Exception
    {
        public DocumentCountException()
        {
        }

        public DocumentCountException(string message) : base(message)
        {
        }

        public DocumentCountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DocumentCountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
