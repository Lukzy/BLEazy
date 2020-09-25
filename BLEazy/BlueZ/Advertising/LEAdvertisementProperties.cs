using System.Collections.Generic;
using Tmds.DBus;

// ReSharper disable ConvertToAutoProperty
// ReSharper disable InconsistentNaming

namespace BLEazy.BlueZ.Advertising
{
    [Dictionary]
    public class LEAdvertisementProperties
    {
        private bool _IncludeTxPower;

        private string _LocalName;

        private IDictionary<string, object> _ManufacturerData;

        private IDictionary<string, object> _ServiceData;

        private string[] _ServiceUUIDs;

        private string[] _SolicitUUIDs;

        private string _Type;

        public string Type
        {
            get => _Type;
            set => _Type = value;
        }

        public string[] ServiceUUIDs
        {
            get => _ServiceUUIDs;
            set => _ServiceUUIDs = value;
        }

        public IDictionary<string, object> ManufacturerData
        {
            get => _ManufacturerData;
            set => _ManufacturerData = value;
        }

        public string[] SolicitUUIDs
        {
            get => _SolicitUUIDs;
            set => _SolicitUUIDs = value;
        }

        public IDictionary<string, object> ServiceData
        {
            get => _ServiceData;
            set => _ServiceData = value;
        }

        public bool IncludeTxPower
        {
            get => _IncludeTxPower;
            set => _IncludeTxPower = value;
        }

        public string LocalName
        {
            get => _LocalName;
            set => _LocalName = value;
        }
    }
}