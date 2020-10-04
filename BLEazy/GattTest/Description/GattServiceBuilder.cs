﻿using BLEazy.Gatt;

namespace BLEazy.GattTest.Description
{
    public class GattServiceBuilder
    {
        public GattServiceBuilder(GattServiceDescription gattServiceServiceDescription)
        {
            ServiceDescription = gattServiceServiceDescription;
        }

        public GattServiceDescription ServiceDescription { get; }

        public void WithCharacteristic(GattCharacteristicDescription gattCharacteristicDescription,
            GattDescriptorDescription[] gattDescriptorDescriptions)
        {
            foreach (var description in gattDescriptorDescriptions)
            {
                gattCharacteristicDescription.AddDescriptor(description);
            }

            ServiceDescription.AddCharacteristic(gattCharacteristicDescription);
        }
    }
}