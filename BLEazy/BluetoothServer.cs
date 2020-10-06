using System;
using System.Threading.Tasks;
using BLEazy.Advertising;
using BLEazy.BlueZ.Adapter;
using BLEazy.Core;
using BLEazy.GattTest;
using Microsoft.Extensions.Logging;

namespace BLEazy
{
    public class BluetoothServer : IDisposable
    {
        private readonly ServerContext _context;

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
            if (_serverTask != null)
            {
                _context.Logger.LogInformation("Bluetooth server already started.");
                return;
            }

            _context.Logger.LogInformation("Starting Bluetooth server.");
            _serverTask = Task.Run(RunBluetoothServer).ContinueWith(x =>
            {
                var errorMessage = x.Exception != null ? x.Exception.Message : "Unknown error occurred.";
                _context.Logger.LogError(errorMessage);
            }, TaskContinuationOptions.OnlyOnFaulted);
        }

        public void Stop()
        {
            if (_serverTask == null || _serverTask.IsFaulted)
            {
                return;
            }

            _serverTask?.Wait();
            _serverTask = null;

            _context.Logger.LogInformation("Bluetooth server stopped.");
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
            /*var application = new GattApplication();

            var gattManager = new GattManager(_context);
            await gattManager.RegisterApplication(application);
            */
            await SampleGattApplication.RegisterGattApplication(_context);
        }
    }
}