﻿using System.Collections.Generic;

namespace BLEazy.GattTest.Description
{
    public class GattCharacteristicDescription
    {
        private readonly IList<GattDescriptorDescription> _Descriptors = new List<GattDescriptorDescription>();

        public IEnumerable<GattDescriptorDescription> Descriptors => _Descriptors;

        public ICharacteristicSource CharacteristicSource { get; set; }

        public string UUID { get; set; }
        public string[] Flags { get; set; }

        public void AddDescriptor(GattDescriptorDescription gattDescriptorDescription)
        {
            _Descriptors.Add(gattDescriptorDescription);
        }
    }
}