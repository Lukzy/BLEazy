using System.Linq;
using BLEazy.BlueZ.Advertising;
using BLEazy.Core;

namespace BLEazy.Advertising
{
    internal static class AdvertisementFactory
    {
        public static LEAdvertisement CreateAdvertisement(ServerContext context)
        {
            var advertisementProperties = new LEAdvertisementProperties
            {
                Type = "peripheral",
                LocalName = context.Configuration.Alias,
                Appearance = context.Configuration.Appearance,
                ServiceUUIDs = context.Configuration.ServiceUUIDs.ToArray()
            };

            var advertisement = new LEAdvertisement("/org/bluez/advertisement0", advertisementProperties);
            return advertisement;
        }
    }
}