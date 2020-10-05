using System.Runtime.CompilerServices;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Gatt
{
    [Dictionary]
    public class GattCharacteristicProperties
    {
        public string UUID { get; set; }

        public ObjectPath Service { get; set; }

        public byte[] Value { get; set; } = default;

        public bool Notifying { get; set; } = default;

        public string[] Flags { get; set; }
    }
}