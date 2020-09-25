using System;
using System.Threading.Tasks;
using Tmds.DBus;

namespace BLEazy.BlueZ.Advertising
{
    [DBusInterface("org.bluez.LEAdvertisement1")]
    public interface ILEAdvertisement : IDBusObject
    {
        Task ReleaseAsync();

        Task<object> GetAsync(string property);

        Task<LEAdvertisementProperties> GetAllAsync();

        Task SetAsync(string property, object value);

        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }
}