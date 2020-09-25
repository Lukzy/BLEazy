using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLEazy.BlueZ.Advertising;
using BLEazy.Core;

namespace BLEazy.Advertising
{
    public class AdvertisingManager
    {
        private readonly ServerContext _context;
        private readonly AdvertisingManagerLogHelper _logHelper;
        private LEAdvertisement _advertisement;

        public AdvertisingManager(ServerContext context)
        {
            _context = context;
            _logHelper = new AdvertisingManagerLogHelper(GetAdvertisingManager(), _context);
        }

        public async Task RegisterAdvertisementAsync()
        {
            if (_advertisement != null)
            {
                _logHelper.LogAlreadyRegisteredAdvertisement();
                return;
            }

            _advertisement = AdvertisementFactory.CreateAdvertisement(_context);
            await _context.Connection.RegisterObjectAsync(_advertisement);
            _logHelper.LogRegisteredDBusAdvertisement(_advertisement.ObjectPath);

            await GetAdvertisingManager().RegisterAdvertisementAsync(_advertisement.ObjectPath, new Dictionary<string, object>());
            await _logHelper.LogRegisteredBluezAdvertisement(_advertisement.ObjectPath);
        }

        public async Task UnregisterAdvertisementAsync()
        {
            if (_advertisement == null)
            {
                _logHelper.LogNoRegisteredAdvertisement();
                return;
            }

            var advertisingManager = GetAdvertisingManager();
            await advertisingManager.UnregisterAdvertisementAsync(_advertisement.ObjectPath);
            await _logHelper.LogUnregisteredBluezAdvertisement(_advertisement.ObjectPath);

            _context.Connection.UnregisterObject(_advertisement.ObjectPath);
            _logHelper.LogUnregisteredDBusAdvertisement(_advertisement.ObjectPath);

            await _advertisement.ReleaseAsync();
            _advertisement = null;
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