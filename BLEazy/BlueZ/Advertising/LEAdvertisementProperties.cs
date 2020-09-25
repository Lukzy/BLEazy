using System.Runtime.CompilerServices;
using Tmds.DBus;

// ReSharper disable ConvertToAutoProperty
// ReSharper disable InconsistentNaming

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Advertising
{
    //TODO Add more properties if they work as expected.
    //TODO Write tests for all properties.

    [Dictionary]
    internal class LEAdvertisementProperties
    {
        private ushort _Appearance;

        private string _LocalName;

        private string[] _ServiceUUIDs;

        private string _Type;

        public string Type
        {
            get => _Type;
            set => _Type = value;
        }

        public string LocalName
        {
            get => _LocalName;
            set => _LocalName = value;
        }

        public ushort Appearance
        {
            get => _Appearance;
            set => _Appearance = value;
        }

        public string[] ServiceUUIDs
        {
            get => _ServiceUUIDs;
            set => _ServiceUUIDs = value;
        }
    }
}