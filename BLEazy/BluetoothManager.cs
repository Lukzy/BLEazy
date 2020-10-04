using System.Threading.Tasks;
using BLEazy.Advertising;
using BLEazy.Core;

namespace BLEazy
{
    public class BluetoothManager
    {
        private readonly AdvertisingManager _advertisingManager;

        public BluetoothManager(ServerContext context)
        {
            context.Connection.ConnectAsync();

            _advertisingManager = new AdvertisingManager(context);
        }

        public async Task StartAdvertisementAsync()
        {
            await _advertisingManager.RegisterAdvertisementAsync();
        }

        public async Task StopAdvertisementAsync()
        {
            await _advertisingManager.UnregisterAdvertisementAsync();
        }
    }
}