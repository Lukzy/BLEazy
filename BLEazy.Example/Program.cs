using System;
using System.Collections.Generic;
using BLEazy.Core;
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
            using var context = new ServerContext(configuration, logger);

            using var bluetoothServer = new BluetoothServer(context);
            bluetoothServer.Start();

            Console.ReadKey();
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
                Appearance = 128,
                ServiceUUIDs = new List<string>
                {
                    "12345678-1234-5678-1234-56789abcdef0"
                }
            };

            return configuration;
        }
    }
}