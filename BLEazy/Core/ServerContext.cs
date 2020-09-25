using System;
using System.Threading.Tasks;
using Tmds.DBus;

namespace BLEazy.Core
{
    public class ServerContext : IDisposable
    {
        public ServerContext(BLEazyConfiguration configuration)
        {
            Configuration = configuration;

            Connection = new Connection(Address.System);
        }

        public Connection Connection { get; }

        public BLEazyConfiguration Configuration { get; }

        public void Dispose()
        {
            Connection.Dispose();
        }

        public async Task ConnectAsync()
        {
            await Connection.ConnectAsync();
        }
    }
}