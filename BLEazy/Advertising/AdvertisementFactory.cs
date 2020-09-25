using BLEazy.BlueZ.Advertising;
using BLEazy.Core;

namespace BLEazy.Advertising
{
    internal static class AdvertisementFactory
    {
        public static LEAdvertisement CreateAdvertisement(ServerContext context)
        {
            var sampleAdvertisement = new LEAdvertisementProperties
            {
                Type = "peripheral",
                LocalName = context.Configuration.LocalName
            };

            var advertisement = new LEAdvertisement("/org/bluez/example/advertisement0", sampleAdvertisement);
            return advertisement;
        }
    }
}