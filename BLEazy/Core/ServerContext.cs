using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Tmds.DBus;

namespace BLEazy.Core
{
    public class ServerContext : IDisposable
    {
        public ServerContext(BLEazyConfiguration configuration, ILogger logger)
        {
            Configuration = configuration;
            Logger = logger;

            Connection = new Connection(Address.System);
        }

        public BLEazyConfiguration Configuration { get; }

        public ILogger Logger { get; }

        public Connection Connection { get; }

        public void Dispose()
        {
            Connection.Dispose();
        }

        public async void Connect()
        {
            await ConnectAsync();
        }

        public async Task ConnectAsync()
        {
            await Connection.ConnectAsync();
        }
    }
}