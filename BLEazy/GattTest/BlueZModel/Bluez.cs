using System.Collections.Generic;
using System.Threading.Tasks;
using Tmds.DBus;

namespace BLEazy.GattTest.BlueZModel
{
    [DBusInterface("org.freedesktop.DBus.ObjectManager")]
    internal interface IObjectManager : IDBusObject
    {
        Task<IDictionary<ObjectPath, IDictionary<string, IDictionary<string, object>>>> GetManagedObjectsAsync();
    }

    [DBusInterface("org.bluez.GattManager1")]
    internal interface IGattManager1 : IDBusObject
    {
        Task RegisterApplicationAsync(ObjectPath application, IDictionary<string, object> options);

        Task UnregisterApplicationAsync(ObjectPath application);
    }
}