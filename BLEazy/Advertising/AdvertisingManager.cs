using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLEazy.BlueZ.Advertising;
using BLEazy.Core;
using Tmds.DBus;

namespace BLEazy.Advertising
{
    public class AdvertisingManager
    {
        private readonly ServerContext _context;
        private readonly AdvertisingManagerLogHelper _logHelper;

        public AdvertisingManager(ServerContext context)
        {
            _context = context;
            _logHelper = new AdvertisingManagerLogHelper(GetAdvertisingManager(), _context);
        }

        public async Task RegisterAdvertisementAsync()
        {
            var advertisement = AdvertisementFactory.CreateAdvertisement(_context);
            await _context.Connection.RegisterObjectAsync(advertisement);
            _logHelper.LogRegisteredDBusAdvertisement(advertisement.ObjectPath);

            await GetAdvertisingManager().RegisterAdvertisementAsync(((IDBusObject) advertisement).ObjectPath, new Dictionary<string, object>());
            await _logHelper.LogRegisteredBluezAdvertisement(advertisement.ObjectPath);
        }

        public async Task UnregisterAdvertisementAsync()
        {
            var advertisement = AdvertisementFactory.CreateAdvertisement(_context);

            var advertisingManager = GetAdvertisingManager();
            await advertisingManager.UnregisterAdvertisementAsync(advertisement.ObjectPath);
            await _logHelper.LogUnregisteredBluezAdvertisement(advertisement.ObjectPath);

            _context.Connection.UnregisterObject(advertisement.ObjectPath);
            _logHelper.LogUnregisteredDBusAdvertisement(advertisement.ObjectPath);
        }

        public async Task<IEnumerable<string>> GetSupportedIncludes()
        {
            var supportedIncludes = await GetAdvertisingManager().GetSupportedIncludesAsync();
            _logHelper.LogSupportedIncludes(supportedIncludes);
            return supportedIncludes.ToList();
        }

        private ILEAdvertisingManager GetAdvertisingManager()
        {
            return _context.Connection.CreateProxy<ILEAdvertisingManager>("org.bluez", "/org/bluez/hci0");
        }
    }
}