using System;
using System.Runtime.Serialization;

namespace GearHunter.Service.Controllers
{
    [Serializable]
    internal class AdvertisementWasNotDeletedException : Exception
    {
        public AdvertisementWasNotDeletedException()
        {
        }

        public AdvertisementWasNotDeletedException(string message) : base(message)
        {
        }

        public AdvertisementWasNotDeletedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AdvertisementWasNotDeletedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}