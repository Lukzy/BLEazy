using System.Collections.Generic;
using System.Threading.Tasks;
using BLEazy.Core;
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

            Task.Run(
                    async () =>
                    {
                        using var context = new ServerContext(peripheralConfiguration, logger);
                        var bluetoothManager = new BluetoothManager(context);

                        await bluetoothManager.StartAdvertisementAsync();
                        await SampleGattApplication.RegisterGattApplication(context);
                        await Task.Delay(-1);

                        await bluetoothManager.StopAdvertisementAsync();
                    })
                .Wait();
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