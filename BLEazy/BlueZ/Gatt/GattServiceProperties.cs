using System.Runtime.CompilerServices;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Gatt
{
    [Dictionary]
    internal class GattServiceProperties
    {
        public string UUID { get; set; }

        public bool Primary { get; set; }

        public ObjectPath[] Characteristics { get; set; }
    }
}