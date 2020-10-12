using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Adapter
{
    internal static class AdapterExtensions
    {
        public static Task<string> GetAddressAsync(this IAdapter adapter)
        {
            return adapter.GetAsync<string>("Address");
        }

        public static Task<string> GetAddressTypeAsync(this IAdapter adapter)
        {
            return adapter.GetAsync<string>("AddressType");
        }

        public static Task<string> GetNameAsync(this IAdapter adapter)
        {
            return adapter.GetAsync<string>("Name");
        }

        public static Task<string> GetAliasAsync(this IAdapter adapter)
        {
            return adapter.GetAsync<string>("Alias");
        }

        public static Task<uint> GetClassAsync(this IAdapter adapter)
        {
            return adapter.GetAsync<uint>("Class");
        }

        public static Task<bool> GetPoweredAsync(this IAdapter adapter)
        {
            return adapter.GetAsync<bool>("Powered");
        }

        public static Task<bool> GetDiscoverableAsync(this IAdapter adapter)
        {
            return adapter.GetAsync<bool>("Discoverable");
        }

        public static Task<uint> GetDiscoverableTimeoutAsync(this IAdapter adapter)
        {
            return adapter.GetAsync<uint>("DiscoverableTimeout");
        }

        public static Task<bool> GetPairableAsync(this IAdapter adapter)
        {
            return adapter.GetAsync<bool>("Pairable");
        }

        public static Task<uint> GetPairableTimeoutAsync(this IAdapter adapter)
        {
            return adapter.GetAsync<uint>("PairableTimeout");
        }

        public static Task<bool> GetDiscoveringAsync(this IAdapter adapter)
        {
            return adapter.GetAsync<bool>("Discovering");
        }

        public static Task<string[]> GetUUIDsAsync(this IAdapter adapter)
        {
            return adapter.GetAsync<string[]>("UUIDs");
        }

        public static Task<string> GetModaliasAsync(this IAdapter adapter)
        {
            return adapter.GetAsync<string>("Modalias");
        }

        public static Task SetAliasAsync(this IAdapter adapter, string value)
        {
            return adapter.SetAsync("Alias", value);
        }

        public static Task SetPoweredAsync(this IAdapter adapter, bool value)
        {
            return adapter.SetAsync("Powered", value);
        }

        public static Task SetDiscoverableAsync(this IAdapter adapter, bool value)
        {
            return adapter.SetAsync("Discoverable", value);
        }

        public static Task SetDiscoverableTimeoutAsync(this IAdapter adapter, uint value)
        {
            return adapter.SetAsync("DiscoverableTimeout", value);
        }

        public static Task SetPairableAsync(this IAdapter adapter, bool value)
        {
            return adapter.SetAsync("Pairable", value);
        }

        public static Task SetPairableTimeoutAsync(this IAdapter adapter, uint value)
        {
            return adapter.SetAsync("PairableTimeout", value);
        }
    }
}