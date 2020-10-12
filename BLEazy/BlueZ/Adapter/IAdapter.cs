using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Adapter
{
    [DBusInterface("org.bluez.Adapter1")]
    internal interface IAdapter : IDBusObject
    {
        Task StartDiscoveryAsync();

        Task SetDiscoveryFilterAsync(IDictionary<string, object> properties);

        Task StopDiscoveryAsync();

        Task RemoveDeviceAsync(ObjectPath device);

        Task<string[]> GetDiscoveryFiltersAsync();

        Task<T> GetAsync<T>(string property);

        Task<AdapterProperties> GetAllAsync();

        Task SetAsync(string property, object value);

        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }
}