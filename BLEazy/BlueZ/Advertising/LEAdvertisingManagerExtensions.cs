using System.Threading.Tasks;

namespace BLEazy.BlueZ.Advertising
{
    public static class LEAdvertisingManagerExtensions
    {
        public static Task<byte> GetActiveInstancesAsync(this ILEAdvertisingManager advertisingManager)
        {
            return advertisingManager.GetAsync<byte>("ActiveInstances");
        }

        public static Task<byte> GetSupportedInstancesAsync(this ILEAdvertisingManager advertisingManager)
        {
            return advertisingManager.GetAsync<byte>("SupportedInstances");
        }

        public static Task<string[]> GetSupportedIncludesAsync(this ILEAdvertisingManager advertisingManager)
        {
            return advertisingManager.GetAsync<string[]>("SupportedIncludes");
        }
    }
}