using System;
using System.Threading.Tasks;
using BLEazy.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace BLEazy.Example
{
    public class Program
    {
        public static async Task Main()
        {
            var logger = CreateLogger();
            logger.LogInformation("BLEazy Example");

            var peripheralConfiguration = new BLEazyConfiguration
            {
                LocalName = "BLEazy"
            };
            using var context = new ServerContext(peripheralConfiguration, logger);

            var bluetoothManager = new BluetoothManager(context);
            await bluetoothManager.StartAdvertisementAsync();

            Console.ReadKey();

            await bluetoothManager.StopAdvertisement();
        }

        private static ILogger CreateLogger()
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole(options =>
            {
                options.Format = ConsoleLoggerFormat.Systemd;
            }));
            var logger = loggerFactory.CreateLogger("BLEazy");
            return logger;
        }
    }
}