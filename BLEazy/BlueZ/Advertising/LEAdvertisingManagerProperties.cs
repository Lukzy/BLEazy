using System.Runtime.CompilerServices;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Advertising
{
    [Dictionary]
    internal class LEAdvertisingManagerProperties
    {
        public byte ActiveInstances { get; set; } = default;

        public byte SupportedInstances { get; set; } = default;

        public string[] SupportedIncludes { get; set; } = default;
    }
}