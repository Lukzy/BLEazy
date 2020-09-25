using System;
using System.Threading.Tasks;
using BLEazy.Advertising;
using BLEazy.BlueZ.Advertising;
using BLEazy.Core;

namespace BLEazy.Example
{
    public class Program
    {
        public static async Task Main()
        {
            Console.WriteLine("BLEazy Example");

            using var context = new DBusContext();
            await context.ConnectAsync();

            var sampleAdvertisement = new LEAdvertisementProperties
            {
                Type = "peripheral",
                ServiceUUIDs = new[]
                {
                    "12345678-1234-5678-1234-56789abcdef0"
                },
                LocalName = "A"
            };

            var advertisingManager = new AdvertisingManager(context);
            var advertisement = advertisingManager.CreateAdvertisement(sampleAdvertisement);
            await advertisingManager.RegisterAdvertisementAsync(advertisement);
                
            Console.WriteLine("Press CTRL+C to quit");
            Console.ReadKey();
        }
    }
}