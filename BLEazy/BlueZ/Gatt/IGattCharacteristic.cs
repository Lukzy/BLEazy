using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Gatt
{
    [DBusInterface("org.bluez.GattCharacteristic1")]
    internal interface IGattCharacteristic : IDBusObject
    {
        Task<byte[]> ReadValueAsync(IDictionary<string, object> options);

        Task WriteValueAsync(byte[] value, IDictionary<string, object> options);

        Task StartNotifyAsync();

        Task StopNotifyAsync();

        Task<object> GetAsync(string property);

        Task<GattCharacteristicProperties> GetAllAsync();

        Task SetAsync(string property, object value);

        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }
}