using System;
using System.Threading.Tasks;
using Tmds.DBus;

namespace BLEazy.Core
{
    public class DBusContext : IDisposable
    {
        public DBusContext()
        {
            Connection = new Connection(Address.System);
        }

        public Connection Connection { get; }

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