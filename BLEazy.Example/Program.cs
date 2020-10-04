using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLEazy.Advertising;
using BLEazy.Core;
using BLEazy.Gatt;
using BLEazy.GattTest;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace BLEazy.Example
{
    public class Program
    {
        public static void Main()
        {
            var logger = CreateLogger();
            logger.LogInformation("BLEazy Example");

            var peripheralConfiguration = new BLEazyConfiguration
            {
                LocalName = "BLEazy",
                Appearance = 0x1000,
                ServiceUUIDs = new List<string>
                {
                    "12345678-1234-5678-1234-56789abcdef0"
                }
            };

            using var context = new ServerContext(peripheralConfiguration, logger);
            var bluetoothServerTask = Task.Run(() => RunBluetoothServer(context));

            Console.ReadKey();

            bluetoothServerTask.Wait();
        }

        private static async Task RunBluetoothServer(ServerContext context)
        {
            await context.ConnectAsync();

            var advertisingManager = new AdvertisingManager(context);
            await advertisingManager.RegisterAdvertisementAsync();

            var application = new GattApplication
            {
                Services = new List<GattServiceDescription>()
            };

            var gattManager = new GattManager(context);
            await gattManager.RegisterApplication(application);

            await SampleGattApplication.RegisterGattApplication(context);
        }

        private static ILogger CreateLogger()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddConsole(options =>
                {
                    options.Format = ConsoleLoggerFormat.Default;
                });
            });
            var logger = loggerFactory.CreateLogger("BLEazy");
            return logger;
        }
    }
}