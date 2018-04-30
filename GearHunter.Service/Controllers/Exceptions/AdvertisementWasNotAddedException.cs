using System;
using System.Runtime.Serialization;

namespace GearHunter.Service.Controllers
{
    [Serializable]
    internal class AdvertisementWasNotAddedException : Exception
    {
        public AdvertisementWasNotAddedException()
        {
        }

        public AdvertisementWasNotAddedException(string message) : base(message)
        {
        }

        public AdvertisementWasNotAddedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AdvertisementWasNotAddedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}