using System.Runtime.CompilerServices;
using Tmds.DBus;

// ReSharper disable ConvertToAutoProperty
// ReSharper disable InconsistentNaming

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Gatt
{
    [Dictionary]
    public class GattDescriptorProperties
    {
        private ObjectPath _Characteristic;

        private string[] _Flags;

        private string _UUID;

        private byte[] _Value;

        public string UUID
        {
            get => _UUID;

            set => _UUID = value;
        }

        public ObjectPath Characteristic
        {
            get => _Characteristic;

            set => _Characteristic = value;
        }

        public byte[] Value
        {
            get => _Value;

            set => _Value = value;
        }

        public string[] Flags
        {
            get => _Flags;

            set => _Flags = value;
        }
    }
}