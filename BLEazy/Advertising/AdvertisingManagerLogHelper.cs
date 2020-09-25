using System.Text;
using System.Threading.Tasks;
using BLEazy.BlueZ.Advertising;
using BLEazy.Core;
using Microsoft.Extensions.Logging;
using Tmds.DBus;

namespace BLEazy.Advertising
{
    internal class AdvertisingManagerLogHelper
    {
        private readonly ILEAdvertisingManager _advertisingManager;
        private readonly ServerContext _context;

        public AdvertisingManagerLogHelper(ILEAdvertisingManager advertisingManager, ServerContext context)
        {
            _advertisingManager = advertisingManager;
            _context = context;
        }

        public async Task LogRegisteredBluezAdvertisement(ObjectPath objectPath)
        {
            var supportedInstances = await _advertisingManager.GetSupportedInstancesAsync();
            var activeInstances = await _advertisingManager.GetActiveInstancesAsync();
            _context.Logger.LogInformation($"Advertisement {objectPath} registered in BlueZ advertising manager. {activeInstances} of {supportedInstances} advertisements used.");
        }

        public async Task LogUnregisteredBluezAdvertisement(ObjectPath objectPath)
        {
            var supportedInstances = await _advertisingManager.GetSupportedInstancesAsync();
            var activeInstances = await _advertisingManager.GetActiveInstancesAsync();
            _context.Logger.LogInformation($"Advertisement {objectPath} unregistered in BlueZ advertising manager. {activeInstances} of {supportedInstances} advertisements used.");
        }

        public void LogRegisteredDBusAdvertisement(ObjectPath objectPath)
        {
            _context.Logger.LogDebug($"Advertisement object {objectPath} registered on DBus System bus.");
        }

        public void LogUnregisteredDBusAdvertisement(ObjectPath objectPath)
        {
            _context.Logger.LogDebug($"Advertisement object {objectPath} unregistered from DBus System bus.");
        }

        public void LogSupportedIncludes(string[] supportedIncludes)
        {
            var stringBuilder = new StringBuilder();
            const string separator = ", ";
            foreach (var supportedInclude in supportedIncludes)
            {
                stringBuilder.Append(supportedInclude);
                stringBuilder.Append(separator);
            }

            stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);
            _context.Logger.LogDebug($"The following includes are supported: {stringBuilder}.");
        }
    }
}