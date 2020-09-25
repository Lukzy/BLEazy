using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLEazy.BlueZ.Advertising;
using BLEazy.Core;
using Microsoft.Extensions.Logging;
using Tmds.DBus;

namespace BLEazy.Advertising
{
    public class AdvertisingManager
    {
        private readonly ServerContext _context;

        public AdvertisingManager(ServerContext context)
        {
            _context = context;
        }

        public async Task RegisterAdvertisementAsync()
        {
            var advertisement = AdvertisementFactory.CreateAdvertisement(_context);
            await _context.Connection.RegisterObjectAsync(advertisement);

            _context.Logger.LogInformation($"Advertisement object {advertisement.ObjectPath} created.");

            var advertisingManager = GetAdvertisingManager();
            var supportedIncludes = await advertisingManager.GetSupportedIncludesAsync();
            var stringBuilder = new StringBuilder();
            foreach (var supportedInclude in supportedIncludes)
            {
                stringBuilder.Append(supportedInclude);
                stringBuilder.Append(", ");
            }
            _context.Logger.LogInformation($"SupportedIncludes: {stringBuilder}.");
            
            _context.Logger.LogInformation($"SupportedInstances: {await advertisingManager.GetSupportedInstancesAsync()}.");
            _context.Logger.LogInformation($"ActiveInstances: {await advertisingManager.GetActiveInstancesAsync()}.");

            await advertisingManager.RegisterAdvertisementAsync(((IDBusObject) advertisement).ObjectPath, new Dictionary<string, object>());
            
            _context.Logger.LogInformation($"SupportedInstances: {await advertisingManager.GetSupportedInstancesAsync()}.");
            _context.Logger.LogInformation($"ActiveInstances: {await advertisingManager.GetActiveInstancesAsync()}.");
            
            _context.Logger.LogInformation($"Advertisement {advertisement.ObjectPath} registered in BlueZ advertising manager.");
        }

        private ILEAdvertisingManager GetAdvertisingManager()
        {
            return _context.Connection.CreateProxy<ILEAdvertisingManager>("org.bluez", "/org/bluez/hci0");
        }
    }
}