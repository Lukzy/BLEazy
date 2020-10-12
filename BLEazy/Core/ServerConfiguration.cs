using System.Collections.Generic;
using System.Linq;
using BLEazy.Gatt.Services;

namespace BLEazy.Core
{
    public class ServerConfiguration
    {
        public string Alias { get; set; }

        public ushort Appearance { get; set; }

        public IList<Service> Services { get; set; }

        public string[] GetServiceUUIDs()
        {
            var serviceUUIDs = Services.Select(x => x.UUID.ToString()).ToArray();
            return serviceUUIDs;
        }
    }
}