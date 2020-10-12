using System.Runtime.CompilerServices;
using Tmds.DBus;

// ReSharper disable ConvertToAutoProperty
// ReSharper disable InconsistentNaming

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Gatt
{
    [Dictionary]
    internal class GattServiceProperties
    {
        private ObjectPath[] _Characteristics;

        private bool _Primary;

        private string _UUID;

        public string UUID
        {
            get => _UUID;

            set => _UUID = value;
        }

        public bool Primary
        {
            get => _Primary;

            set => _Primary = value;
        }

        public ObjectPath[] Characteristics
        {
            get => _Characteristics;

            set => _Characteristics = value;
        }
    }
}