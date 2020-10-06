using System.Collections.Generic;
using BLEazy.Gatt.Sources;

namespace BLEazy.Gatt.Descriptions
{
    public class GattCharacteristicDescription : GattDescription
    {
        private readonly IList<GattDescriptorDescription> _descriptors = new List<GattDescriptorDescription>();

        public IEnumerable<GattDescriptorDescription> Descriptors => _descriptors;

        public ICharacteristicSource CharacteristicSource { get; set; }

        public string[] Flags { get; set; }

        public void AddDescriptor(GattDescriptorDescription gattDescriptorDescription)
        {
            _descriptors.Add(gattDescriptorDescription);
        }
    }
}