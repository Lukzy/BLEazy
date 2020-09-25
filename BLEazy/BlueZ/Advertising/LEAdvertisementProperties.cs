﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Tmds.DBus;

// ReSharper disable ConvertToAutoProperty
// ReSharper disable InconsistentNaming

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Advertising
{
    //TODO: Test all properties! The following properties work (tested with nRF Connect v3.5.0): LocalName, ServiceUUIDs, Type (only peripheral), Appearance

    [Dictionary]
    internal class LEAdvertisementProperties
    {
        private bool _IncludeTxPower;

        private string _LocalName;

        private IDictionary<string, object> _ManufacturerData;

        private IDictionary<string, object> _ServiceData;

        private string[] _ServiceUUIDs;

        private string[] _SolicitUUIDs;

        private string _Type;

        private ushort _Appearance;

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

        public ushort Appearance
        {
            get => _Appearance;
            set => _Appearance = value;
        }
    }
}