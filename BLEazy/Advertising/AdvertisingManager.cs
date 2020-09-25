using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLEazy.BlueZ.Advertising;
using BLEazy.Core;
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
            Console.WriteLine($"advertisement object {advertisement.ObjectPath} created");

            var advertisingManager = GetAdvertisingManager();
            var supportedIncludes = await advertisingManager.GetSupportedIncludesAsync();
            var stringBuilder = new StringBuilder();
            foreach (var supportedInclude in supportedIncludes)
            {
                stringBuilder.Append(supportedInclude);
                stringBuilder.Append(", ");
            }
            Console.WriteLine($"SupportedIncludes: {stringBuilder}");

            Console.WriteLine($"SupportedInstances: {await advertisingManager.GetSupportedInstancesAsync()}");
            Console.WriteLine($"ActiveInstances: {await advertisingManager.GetActiveInstancesAsync()}");

            await advertisingManager.RegisterAdvertisementAsync(((IDBusObject) advertisement).ObjectPath, new Dictionary<string, object>());

            Console.WriteLine($"SupportedInstances: {await advertisingManager.GetSupportedInstancesAsync()}");
            Console.WriteLine($"ActiveInstances: {await advertisingManager.GetActiveInstancesAsync()}");

            Console.WriteLine($"advertisement {advertisement.ObjectPath} registered in BlueZ advertising manager");
        }

        private ILEAdvertisingManager GetAdvertisingManager()
        {
            return _context.Connection.CreateProxy<ILEAdvertisingManager>("org.bluez", "/org/bluez/hci0");
        }
    }
}