using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Gatt
{
    [DBusInterface("org.bluez.GattDescriptor1")]
    internal interface IGattDescriptor : IDBusObject
    {
        Task<byte[]> ReadValueAsync();

        Task<object> GetAsync(string property);

        Task<GattDescriptorProperties> GetAllAsync();

        Task SetAsync(string property, object value);

        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }
}