using System;
using System.Threading;
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
        private CancellationTokenSource _cancellationTokenSource;
        private GattManager _gattManager;
        private Task _serverTask;
        private CancellationToken _token;

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

            _cancellationTokenSource = new CancellationTokenSource();
            _token = _cancellationTokenSource.Token;

            _context.Logger.LogInformation("Starting Bluetooth server.");
            _serverTask = Task.Run(RunBluetoothServer, _token).ContinueWith(x =>
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

            _cancellationTokenSource.Cancel();
            UnregisterGatt();
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
            //var application = new GattApplication();
            //TODO refactor creation of application and services
            var serviceDescriptions = SampleGattApplication.BuildServiceDescriptions();
            _gattManager = new GattManager(_context);
            await _gattManager.RegisterApplication(serviceDescriptions);

            _context.Logger.LogInformation("Gatt application registered.");
        }

        private void UnregisterGatt()
        {
            _gattManager?.UnregisterApplication().Wait(1000);

            _context.Logger.LogInformation("Gatt application unregistered.");
        }
    }
}