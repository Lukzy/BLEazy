using Tmds.DBus;

namespace BLEazy.BlueZ.Advertising
{
    [Dictionary]
    public class LEAdvertisingManagerProperties
    {
        public byte ActiveInstances { get; set; } = default;

        public byte SupportedInstances { get; set; } = default;

        public string[] SupportedIncludes { get; set; } = default;
    }
}