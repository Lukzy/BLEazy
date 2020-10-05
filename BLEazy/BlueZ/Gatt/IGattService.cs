using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Gatt
{
    [DBusInterface("org.bluez.GattService1")]
    internal interface IGattService : IDBusObject
    {
        Task<object> GetAsync(string property);

        Task<GattServiceProperties> GetAllAsync();

        Task SetAsync(string property, object value);

        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }
}