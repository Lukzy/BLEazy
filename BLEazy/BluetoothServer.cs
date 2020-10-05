using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLEazy.Advertising;
using BLEazy.BlueZ.Adapter;
using BLEazy.Core;
using BLEazy.Gatt;
using BLEazy.GattTest;
using Microsoft.Extensions.Logging;

namespace BLEazy
{
    public class BluetoothServer : IDisposable
    {
        private readonly ServerContext _context;
        private readonly object _sync = new object();

        private Task _serverTask;

        public BluetoothServer(ServerContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Stop();

            _context?.Dispose();
        }

        public void Start()
        {
            lock (_sync)
            {
                _context.Logger.LogInformation("Starting Bluetooth server.");

                _serverTask = Task.Run(RunBluetoothServer);
            }
        }

        public void Stop()
        {
            lock (_sync)
            {
                _serverTask?.Wait();

                _context.Logger.LogInformation("Bluetooth server stopped.");
            }
        }

        private async Task RunBluetoothServer()
        {
            await InitializeServerAsync();
            await ApplyConfigurationAsync();
            await RegisterAdvertisementAsync();
            await RegisterGattAsync();

            _context.Logger.LogInformation("Bluetooth server started.");
        }

        private async Task InitializeServerAsync()
        {
            await _context.ConnectAsync();
        }

        private async Task ApplyConfigurationAsync()
        {
            var adapter = _context.CreateProxy<IAdapter>();
            await adapter.SetAliasAsync(_context.Configuration.Alias);
        }

        private async Task RegisterAdvertisementAsync()
        {
            var advertisingManager = new AdvertisingManager(_context);
            await advertisingManager.RegisterAdvertisementAsync();
        }

        private async Task RegisterGattAsync()
        {
            var application = new GattApplication
            {
                Services = new List<GattServiceDescription>()
            };

            var gattManager = new GattManager(_context);
            await gattManager.RegisterApplication(application);
            await SampleGattApplication.RegisterGattApplication(_context);
        }
    }
}