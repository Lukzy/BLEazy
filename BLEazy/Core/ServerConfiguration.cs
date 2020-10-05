using System.Collections.Generic;

namespace BLEazy.Core
{
    public class ServerConfiguration
    {
        public string Alias { get; set; }

        public ushort Appearance { get; set; }

        public IEnumerable<string> ServiceUUIDs { get; set; }
    }
}