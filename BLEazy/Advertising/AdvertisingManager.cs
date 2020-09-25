using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLEazy.BlueZ.Advertising;
using BLEazy.Core;
using Tmds.DBus;

namespace BLEazy.Advertising
{
    public class AdvertisingManager
    {
        private readonly DBusContext _context;

        public AdvertisingManager(DBusContext context)
        {
            _context = context;
        }

        public async Task RegisterAdvertisementAsync(LEAdvertisement advertisement)
        {
            await _context.Connection.RegisterObjectAsync(advertisement);
            Console.WriteLine($"advertisement object {advertisement.ObjectPath} created");

            await GetAdvertisingManager().RegisterAdvertisementAsync(((IDBusObject) advertisement).ObjectPath, new Dictionary<string, object>());

            Console.WriteLine($"advertisement {advertisement.ObjectPath} registered in BlueZ advertising manager");
        }

        private ILEAdvertisingManager GetAdvertisingManager()
        {
            return _context.Connection.CreateProxy<ILEAdvertisingManager>("org.bluez", "/org/bluez/hci0");
        }

        public LEAdvertisement CreateAdvertisement(LEAdvertisementProperties advertisementProperties)
        {
            var advertisement = new LEAdvertisement("/org/bluez/example/advertisement0", advertisementProperties);
            return advertisement;
        }
    }
}