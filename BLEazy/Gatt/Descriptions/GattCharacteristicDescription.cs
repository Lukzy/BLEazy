using BLEazy.Gatt.Sources;

namespace BLEazy.Gatt.Descriptions
{
    public class GattCharacteristicDescription : GattDescription
    {
        public ICharacteristicSource CharacteristicSource { get; set; }

        public string[] Flags { get; set; }
    }
}