using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Advertising
{
    [DBusInterface("org.bluez.LEAdvertisement1")]
    internal interface ILEAdvertisement : IDBusObject
    {
        Task ReleaseAsync();

        Task<object> GetAsync(string property);

        Task<LEAdvertisementProperties> GetAllAsync();

        Task SetAsync(string property, object value);

        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }
}