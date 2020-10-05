using System.Runtime.CompilerServices;
using Tmds.DBus;

// ReSharper disable ConvertToAutoProperty
// ReSharper disable InconsistentNaming

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Gatt
{
    [Dictionary]
    public class GattCharacteristicProperties
    {
        private string[] _Flags;

        private bool _Notifying;

        private ObjectPath _Service;

        private string _UUID;

        private byte[] _Value;

        public string UUID
        {
            get => _UUID;

            set => _UUID = value;
        }

        public ObjectPath Service
        {
            get => _Service;

            set => _Service = value;
        }

        public byte[] Value
        {
            get => _Value;

            set => _Value = value;
        }

        public bool Notifying
        {
            get => _Notifying;

            set => _Notifying = value;
        }

        public string[] Flags
        {
            get => _Flags;

            set => _Flags = value;
        }
    }
}