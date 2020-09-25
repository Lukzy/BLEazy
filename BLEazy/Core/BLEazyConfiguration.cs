using System.Collections.Generic;

namespace BLEazy.Core
{
    public class BLEazyConfiguration
    {
        public string LocalName { get; set; }

        public ushort Appearance { get; set; }

        public IEnumerable<string> ServiceUUIDs { get; set; }
    }
}