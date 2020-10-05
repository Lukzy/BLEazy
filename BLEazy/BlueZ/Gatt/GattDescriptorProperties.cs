using System.Runtime.CompilerServices;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Gatt
{
    [Dictionary]
    public class GattDescriptorProperties
    {
        public string UUID { get; set; }

        public ObjectPath Characteristic { get; set; }

        public byte[] Value { get; set; }

        public string[] Flags { get; set; }
    }
}