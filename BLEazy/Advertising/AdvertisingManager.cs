using System;
using System.Collections.Generic;
using System.Linq;
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
            _context.Logger.LogInformation($"Advertisement object {advertisement.ObjectPath} registered in DBus System bus.");

            var advertisingManager = GetAdvertisingManager();
            
            _context.Logger.LogInformation($"SupportedInstances: {await advertisingManager.GetSupportedInstancesAsync()}.");
            _context.Logger.LogInformation($"ActiveInstances: {await advertisingManager.GetActiveInstancesAsync()}.");

            await advertisingManager.RegisterAdvertisementAsync(((IDBusObject) advertisement).ObjectPath, new Dictionary<string, object>());
            
            _context.Logger.LogInformation($"SupportedInstances: {await advertisingManager.GetSupportedInstancesAsync()}.");
            _context.Logger.LogInformation($"ActiveInstances: {await advertisingManager.GetActiveInstancesAsync()}.");
            
            _context.Logger.LogInformation($"Advertisement {advertisement.ObjectPath} registered in BlueZ advertising manager.");
        }

        public void UnregisterAdvertisementAsync()
        {
            var advertisement = AdvertisementFactory.CreateAdvertisement(_context);
            _context.Connection.UnregisterObject(advertisement);
            _context.Logger.LogInformation($"Advertisement object {advertisement.ObjectPath} unregistered.");
        }

        public async Task<IEnumerable<string>> GetSupportedIncludes()
        {
            var supportedIncludes = await GetAdvertisingManager().GetSupportedIncludesAsync();

            var stringBuilder = new StringBuilder();
            const string separator = ", ";
            foreach (var supportedInclude in supportedIncludes)
            {
                stringBuilder.Append(supportedInclude);
                stringBuilder.Append(separator);
            }

            stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);
            _context.Logger.LogDebug($"SupportedIncludes: {stringBuilder}.");

            return supportedIncludes.ToList();
        }

        private ILEAdvertisingManager GetAdvertisingManager()
        {
            return _context.Connection.CreateProxy<ILEAdvertisingManager>("org.bluez", "/org/bluez/hci0");
        }
    }
}