using System.Collections.Generic;

namespace BLEazy.Gatt.Descriptions
{
    public class GattServiceDescription : GattDescription
    {
        public IList<GattCharacteristicDescription> GattCharacteristicDescriptions { get; } =
            new List<GattCharacteristicDescription>();

        public bool Primary { get; set; }

        public void AddCharacteristic(GattCharacteristicDescription characteristic)
        {
            GattCharacteristicDescriptions.Add(characteristic);
        }

        public void RemoveCharacteristic(GattCharacteristicDescription characteristic)
        {
            GattCharacteristicDescriptions.Remove(characteristic);
        }
    }
}