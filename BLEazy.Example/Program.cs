using System;
using BLEazy.Core;
using BLEazy.Gatt.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace BLEazy.Example
{
    public class Program
    {
        public static void Main()
        {
            var logger = CreateLogger();
            var configuration = CreateConfiguration();
            var service = new Service(new UUID("12345678-1234-5678-1234-56789abcdef0"), true);
            service.Characteristics.Add(new ExampleCharacteristic());
            configuration.Services.Add(service);
            using var context = new ServerContext(configuration, logger);

            using var bluetoothServer = new BluetoothServer(context);
            bluetoothServer.Start();

            Console.ReadKey();
            bluetoothServer.Stop();
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

        private static ServerConfiguration CreateConfiguration()
        {
            var configuration = new ServerConfiguration
            {
                Alias = "BLEazy",
                Appearance = 128
            };

            return configuration;
        }
    }
}