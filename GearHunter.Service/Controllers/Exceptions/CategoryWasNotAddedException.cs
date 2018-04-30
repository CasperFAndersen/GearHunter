using System;
using System.Runtime.Serialization;

namespace GearHunter.Service.Controllers
{
    [Serializable]
    internal class CategoryWasNotAddedException : Exception
    {
        public CategoryWasNotAddedException()
        {
        }

        public CategoryWasNotAddedException(string message) : base(message)
        {
        }

        public CategoryWasNotAddedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CategoryWasNotAddedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}