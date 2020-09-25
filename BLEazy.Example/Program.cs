using System;
using System.Threading.Tasks;
using BLEazy.Advertising;
using BLEazy.Core;

namespace BLEazy.Example
{
    public class Program
    {
        public static async Task Main()
        {
            Console.WriteLine("BLEazy Example");

            var peripheralConfiguration = new BLEazyConfiguration
            {
                LocalName = "BLEazy"
            };

            using var context = new ServerContext(peripheralConfiguration);
            await context.ConnectAsync();

            var advertisingManager = new AdvertisingManager(context);
            await advertisingManager.RegisterAdvertisementAsync();

            Console.WriteLine("Press CTRL+C to quit");
            Console.ReadKey();
        }
    }
}