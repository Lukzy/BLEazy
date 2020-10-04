using System.Collections.Generic;

namespace BLEazy.GattTest.Description
{
    public class GattCharacteristicDescription
    {
        private readonly IList<GattDescriptorDescription> _descriptors = new List<GattDescriptorDescription>();

        public IEnumerable<GattDescriptorDescription> Descriptors => _descriptors;

        public ICharacteristicSource CharacteristicSource { get; set; }

        public string UUID { get; set; }
        public string[] Flags { get; set; }

        public void AddDescriptor(GattDescriptorDescription gattDescriptorDescription)
        {
            _descriptors.Add(gattDescriptorDescription);
        }
    }
}