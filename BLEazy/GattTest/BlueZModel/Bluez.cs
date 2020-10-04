using System.Collections.Generic;
using System.Threading.Tasks;
using Tmds.DBus;

namespace BLEazy.GattTest.BlueZModel
{
    [DBusInterface("org.freedesktop.DBus.ObjectManager")]
    interface IObjectManager : IDBusObject
    {
        Task<IDictionary<ObjectPath, IDictionary<string, IDictionary<string, object>>>> GetManagedObjectsAsync();
    }
    
    [DBusInterface("org.bluez.GattManager1")]
    interface IGattManager1 : IDBusObject
    {
        Task RegisterApplicationAsync(ObjectPath Application, IDictionary<string, object> Options);
        Task UnregisterApplicationAsync(ObjectPath Application);
    }
}