using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Gatt
{
    [DBusInterface("org.bluez.GattManager1")]
    internal interface IGattManager : IDBusObject
    {
        Task RegisterApplicationAsync(ObjectPath application, IDictionary<string, object> options);

        Task UnregisterApplicationAsync(ObjectPath application);
    }
}