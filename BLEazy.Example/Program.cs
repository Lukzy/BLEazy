using System;
using System.Threading.Tasks;
using BLEazy.Advertising;
using BLEazy.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace BLEazy.Example
{
    public class Program
    {
        public static async Task Main()
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole(options => {
                options.Format=ConsoleLoggerFormat.Systemd;
            }));
            var logger = loggerFactory.CreateLogger("BLEazy");

            logger.LogInformation("BLEazy Example");

            var peripheralConfiguration = new BLEazyConfiguration
            {
                LocalName = "BLEazy"
            };

            using var context = new ServerContext(peripheralConfiguration, logger);
            await context.ConnectAsync();

            var advertisingManager = new AdvertisingManager(context);
            await advertisingManager.RegisterAdvertisementAsync();
            
            Console.WriteLine("Press CTRL+C to quit");
            Console.ReadKey();
        }
    }
}