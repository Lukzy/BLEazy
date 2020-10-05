using System.Runtime.CompilerServices;
using Tmds.DBus;

// ReSharper disable ConvertToAutoProperty
// ReSharper disable InconsistentNaming

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Adapter
{
    [Dictionary]
    internal class AdapterProperties
    {
        private string _Address;

        private string _AddressType;

        private string _Alias;

        private uint _Class;

        private bool _Discoverable;

        private uint _DiscoverableTimeout;

        private bool _Discovering;

        private string _Modalias;

        private string _Name;

        private bool _Pairable;

        private uint _PairableTimeout;

        private bool _Powered;

        private string[] _UUIDs;

        public string Address
        {
            get => _Address;

            set => _Address = value;
        }

        public string AddressType
        {
            get => _AddressType;

            set => _AddressType = value;
        }

        public string Name
        {
            get => _Name;

            set => _Name = value;
        }

        public string Alias
        {
            get => _Alias;

            set => _Alias = value;
        }

        public uint Class
        {
            get => _Class;

            set => _Class = value;
        }

        public bool Powered
        {
            get => _Powered;

            set => _Powered = value;
        }

        public bool Discoverable
        {
            get => _Discoverable;

            set => _Discoverable = value;
        }

        public uint DiscoverableTimeout
        {
            get => _DiscoverableTimeout;

            set => _DiscoverableTimeout = value;
        }

        public bool Pairable
        {
            get => _Pairable;

            set => _Pairable = value;
        }

        public uint PairableTimeout
        {
            get => _PairableTimeout;

            set => _PairableTimeout = value;
        }

        public bool Discovering
        {
            get => _Discovering;

            set => _Discovering = value;
        }

        public string[] UUIDs
        {
            get => _UUIDs;

            set => _UUIDs = value;
        }

        public string Modalias
        {
            get => _Modalias;

            set => _Modalias = value;
        }
    }
}