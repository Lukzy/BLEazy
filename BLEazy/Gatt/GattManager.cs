using BLEazy.Core;
using Microsoft.Extensions.Logging;

namespace BLEazy.Gatt
{
    public class GattManager
    {
        public GattManager(ServerContext context)
        {
            context.Logger.LogInformation("GattManager started");
        }

        /*
        public async Task RegisterApplication(GattApplication application)
        {
            await Task.CompletedTask;
        }*/
    }
}