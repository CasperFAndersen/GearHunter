using System;
using System.Runtime.Serialization;

namespace GearHunter.Service.Controllers
{
    [Serializable]
    internal class CompanyWasNotAddedException : Exception
    {
        public CompanyWasNotAddedException()
        {
        }

        public CompanyWasNotAddedException(string message) : base(message)
        {
        }

        public CompanyWasNotAddedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CompanyWasNotAddedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}