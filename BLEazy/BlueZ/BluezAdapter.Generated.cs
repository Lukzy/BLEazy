using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tmds.DBus;

namespace BLEazy.BlueZ
{
    [DBusInterface("org.bluez.Adapter1")]
    interface IBluezAdapter : IDBusObject
    {
        Task StartDiscoveryAsync();
        Task SetDiscoveryFilterAsync(IDictionary<string, object> Properties);
        Task StopDiscoveryAsync();
        Task RemoveDeviceAsync(ObjectPath Device);
        Task<string[]> GetDiscoveryFiltersAsync();
        Task<T> GetAsync<T>(string prop);
        Task<BluezAdapterProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class BluezAdapterProperties
    {
        private string _Address = default(string);
        public string Address
        {
            get
            {
                return _Address;
            }

            set
            {
                _Address = (value);
            }
        }

        private string _AddressType = default(string);
        public string AddressType
        {
            get
            {
                return _AddressType;
            }

            set
            {
                _AddressType = (value);
            }
        }

        private string _Name = default(string);
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = (value);
            }
        }

        private string _Alias = default(string);
        public string Alias
        {
            get
            {
                return _Alias;
            }

            set
            {
                _Alias = (value);
            }
        }

        private uint _Class = default(uint);
        public uint Class
        {
            get
            {
                return _Class;
            }

            set
            {
                _Class = (value);
            }
        }

        private bool _Powered = default(bool);
        public bool Powered
        {
            get
            {
                return _Powered;
            }

            set
            {
                _Powered = (value);
            }
        }

        private bool _Discoverable = default(bool);
        public bool Discoverable
        {
            get
            {
                return _Discoverable;
            }

            set
            {
                _Discoverable = (value);
            }
        }

        private uint _DiscoverableTimeout = default(uint);
        public uint DiscoverableTimeout
        {
            get
            {
                return _DiscoverableTimeout;
            }

            set
            {
                _DiscoverableTimeout = (value);
            }
        }

        private bool _Pairable = default(bool);
        public bool Pairable
        {
            get
            {
                return _Pairable;
            }

            set
            {
                _Pairable = (value);
            }
        }

        private uint _PairableTimeout = default(uint);
        public uint PairableTimeout
        {
            get
            {
                return _PairableTimeout;
            }

            set
            {
                _PairableTimeout = (value);
            }
        }

        private bool _Discovering = default(bool);
        public bool Discovering
        {
            get
            {
                return _Discovering;
            }

            set
            {
                _Discovering = (value);
            }
        }

        private string[] _UUIDs = default(string[]);
        public string[] UUIDs
        {
            get
            {
                return _UUIDs;
            }

            set
            {
                _UUIDs = (value);
            }
        }

        private string _Modalias = default(string);
        public string Modalias
        {
            get
            {
                return _Modalias;
            }

            set
            {
                _Modalias = (value);
            }
        }
    }

    static class BluezAdapterExtensions
    {
        public static Task<string> GetAddressAsync(this IBluezAdapter o) => o.GetAsync<string>("Address");
        public static Task<string> GetAddressTypeAsync(this IBluezAdapter o) => o.GetAsync<string>("AddressType");
        public static Task<string> GetNameAsync(this IBluezAdapter o) => o.GetAsync<string>("Name");
        public static Task<string> GetAliasAsync(this IBluezAdapter o) => o.GetAsync<string>("Alias");
        public static Task<uint> GetClassAsync(this IBluezAdapter o) => o.GetAsync<uint>("Class");
        public static Task<bool> GetPoweredAsync(this IBluezAdapter o) => o.GetAsync<bool>("Powered");
        public static Task<bool> GetDiscoverableAsync(this IBluezAdapter o) => o.GetAsync<bool>("Discoverable");
        public static Task<uint> GetDiscoverableTimeoutAsync(this IBluezAdapter o) => o.GetAsync<uint>("DiscoverableTimeout");
        public static Task<bool> GetPairableAsync(this IBluezAdapter o) => o.GetAsync<bool>("Pairable");
        public static Task<uint> GetPairableTimeoutAsync(this IBluezAdapter o) => o.GetAsync<uint>("PairableTimeout");
        public static Task<bool> GetDiscoveringAsync(this IBluezAdapter o) => o.GetAsync<bool>("Discovering");
        public static Task<string[]> GetUUIDsAsync(this IBluezAdapter o) => o.GetAsync<string[]>("UUIDs");
        public static Task<string> GetModaliasAsync(this IBluezAdapter o) => o.GetAsync<string>("Modalias");
        public static Task SetAliasAsync(this IBluezAdapter o, string val) => o.SetAsync("Alias", val);
        public static Task SetPoweredAsync(this IBluezAdapter o, bool val) => o.SetAsync("Powered", val);
        public static Task SetDiscoverableAsync(this IBluezAdapter o, bool val) => o.SetAsync("Discoverable", val);
        public static Task SetDiscoverableTimeoutAsync(this IBluezAdapter o, uint val) => o.SetAsync("DiscoverableTimeout", val);
        public static Task SetPairableAsync(this IBluezAdapter o, bool val) => o.SetAsync("Pairable", val);
        public static Task SetPairableTimeoutAsync(this IBluezAdapter o, uint val) => o.SetAsync("PairableTimeout", val);
    }
}