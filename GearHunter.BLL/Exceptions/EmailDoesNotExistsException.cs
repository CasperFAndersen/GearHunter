using System;
using System.Runtime.Serialization;

namespace GearHunter.BLL
{
    [Serializable]
    internal class EmailDoesNotExistsException : Exception
    {
        public EmailDoesNotExistsException()
        {
        }

        public EmailDoesNotExistsException(string message) : base(message)
        {
        }

        public EmailDoesNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmailDoesNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}