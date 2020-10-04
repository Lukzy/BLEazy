using System;
using System.Collections.Generic;
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
                LocalName = "BLEazy",
                Appearance = 0x1000,
                ServiceUUIDs = new List<string>
                {
                    "0x1805",
                    "0x180A"
                }
            };
            using var context = new ServerContext(peripheralConfiguration, logger);

            var bluetoothManager = new BluetoothManager(context);
            await bluetoothManager.StartAdvertisementAsync();

            Console.ReadKey();

            await bluetoothManager.StopAdvertisementAsync();
        }

        private static ILogger CreateLogger()
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole(options =>
            {
                options.Format = ConsoleLoggerFormat.Default;
            }));
            var logger = loggerFactory.CreateLogger("BLEazy");
            return logger;
        }
    }
}