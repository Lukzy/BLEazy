using System.Collections.Generic;
using System.Threading.Tasks;
using BLEazy.BlueZ.Gatt;
using BLEazy.Core;
using BLEazy.Gatt.Services;
using Microsoft.Extensions.Logging;

namespace BLEazy.Gatt
{
    public class GattManager
    {
        private readonly ServerContext _context;
        private readonly GattApplication _application;

        public GattManager(ServerContext context)
        {
            _context = context;
            _application = new GattApplication();

            context.Logger.LogInformation("GattManager started");
        }

        public async Task RegisterApplicationAsync()
        {
            await _context.RegisterObjectAsync(_application);

            await AddServicesAsync();

            var gattManager = _context.CreateProxy<IGattManager>();
            await gattManager.RegisterApplicationAsync(_application.ObjectPath, new Dictionary<string, object>());
        }
        
        public async Task UnregisterApplicationAsync()
        {
            var gattManager = _context.CreateProxy<IGattManager>();
            await gattManager.UnregisterApplicationAsync(_application.ObjectPath);
        }

        private async Task AddServicesAsync()
        {
            foreach (var service in _context.Configuration.Services)
            {
                var gattServiceProperties = GattPropertiesFactory.CreateGattService(service);
                var gattService = _application.AddService(gattServiceProperties);
                await _context.RegisterObjectAsync(gattService);

                await AddCharacteristicAsync(service, gattService);
            }
        }

        private async Task AddCharacteristicAsync(Service service, GattService gattService)
        {
            foreach (var characteristic in service.Characteristics)
            {
                var gattCharacteristicProperties = GattPropertiesFactory.CreateGattCharacteristic(characteristic);
                var gattCharacteristic = gattService.AddCharacteristic(gattCharacteristicProperties, characteristic);
                await _context.RegisterObjectAsync(gattCharacteristic);
            }
        }
    }
}