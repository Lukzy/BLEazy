using System.Collections.Generic;

namespace BLEazy.Gatt
{
    public class GattApplication
    {
        public IList<GattServiceDescription> Services { get; set; } = new List<GattServiceDescription>();

        public void AddService(GattServiceDescription service)
        {
            Services.Add(service);
        }

        public void RemoveService(GattServiceDescription service)
        {
            Services.Remove(service);
        }
    }
}