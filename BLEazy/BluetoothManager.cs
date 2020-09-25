using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BLEazy.Advertising;
using BLEazy.Core;
using Microsoft.Extensions.Logging;

namespace BLEazy
{
    public class BluetoothManager
    {
        private readonly AdvertisingManager _advertisingManager;
        private readonly ServerContext _context;

        public BluetoothManager(ServerContext context)
        {
            _context = context;
            _context.Connection.ConnectAsync();

            _advertisingManager = new AdvertisingManager(context);
        }

        public async Task StartAdvertisementAsync()
        {
            await _advertisingManager.RegisterAdvertisementAsync();
        }

        public void StopAdvertisement()
        {
            _advertisingManager.UnregisterAdvertisementAsync();
        }
    }
}