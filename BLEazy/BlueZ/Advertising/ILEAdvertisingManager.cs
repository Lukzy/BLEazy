using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tmds.DBus;

namespace BLEazy.BlueZ.Advertising
{
    [DBusInterface("org.bluez.LEAdvertisingManager1")]
    public interface ILEAdvertisingManager : IDBusObject
    {
        Task RegisterAdvertisementAsync(ObjectPath advertisement, IDictionary<string, object> options);

        Task UnregisterAdvertisementAsync(ObjectPath service);

        Task<T> GetAsync<T>(string property);

        Task<LEAdvertisingManagerProperties> GetAllAsync();

        Task SetAsync(string property, object value);

        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }
}