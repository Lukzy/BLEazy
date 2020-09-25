using BLEazy.BlueZ.Advertising;

namespace BLEazy.Advertising
{
    public static class AdvertisementFactory
    {
        public static LEAdvertisement CreateAdvertisement()
        {
            var advertisement = new LEAdvertisement("/org/bluez/example/advertisement0", null);
            return advertisement;
        }
    }
}