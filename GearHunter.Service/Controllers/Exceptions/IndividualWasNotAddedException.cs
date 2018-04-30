using System;
using System.Runtime.Serialization;

namespace GearHunter.Service.Controllers
{
    [Serializable]
    internal class IndividualWasNotAddedException : Exception
    {
        public IndividualWasNotAddedException()
        {
        }

        public IndividualWasNotAddedException(string message) : base(message)
        {
        }

        public IndividualWasNotAddedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IndividualWasNotAddedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}