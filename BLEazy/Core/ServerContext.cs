using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Tmds.DBus;

namespace BLEazy.Core
{
    public class ServerContext : IDisposable
    {
        private const string BluezServiceName = "org.bluez";
        private const string DefaultAdapterPath = "/org/bluez/hci0";

        private readonly Connection _connection;

        public ServerContext(BLEazyConfiguration configuration, ILogger logger)
        {
            Configuration = configuration;
            Logger = logger;

            _connection = new Connection(Address.System);
        }

        public BLEazyConfiguration Configuration { get; }

        public ILogger Logger { get; }

        public void Dispose()
        {
            _connection.Dispose();
        }

        public async Task ConnectAsync()
        {
            await _connection.ConnectAsync();
        }

        public T CreateProxy<T>()
        {
            return _connection.CreateProxy<T>(BluezServiceName, DefaultAdapterPath);
        }

        public async Task RegisterObjectAsync(IDBusObject dBusObject)
        {
            await _connection.RegisterObjectAsync(dBusObject);
        }

        public void UnregisterObject(ObjectPath path)
        {
            _connection.UnregisterObject(path);
        }
    }
}