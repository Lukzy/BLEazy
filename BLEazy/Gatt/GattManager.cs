using System.Collections.Generic;
using System.Threading.Tasks;
using BLEazy.BlueZ.Gatt;
using BLEazy.Core;
using BLEazy.Gatt.Descriptions;
using Microsoft.Extensions.Logging;

namespace BLEazy.Gatt
{
    public class GattManager
    {
        private readonly ServerContext _context;

        private GattApplication _application;

        public GattManager(ServerContext context)
        {
            _context = context;
            context.Logger.LogInformation("GattManager started");
        }

        public async Task RegisterApplication(IEnumerable<GattServiceDescription> gattServiceDescriptions)
        {
            _application = await new GattApplicationManager(_context).BuildApplicationTree(gattServiceDescriptions);
            var gattManager = _context.CreateProxy<IGattManager>();
            await gattManager.RegisterApplicationAsync(_application.ObjectPath, new Dictionary<string, object>());
        }

        public async Task UnregisterApplication()
        {
            var gattManager = _context.CreateProxy<IGattManager>();
            await gattManager.UnregisterApplicationAsync(_application.ObjectPath);
        }
    }
}