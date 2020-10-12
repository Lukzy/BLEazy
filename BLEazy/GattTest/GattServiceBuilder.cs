﻿using BLEazy.Gatt.Descriptions;

namespace BLEazy.GattTest
{
    public class GattServiceBuilder
    {
        public GattServiceBuilder(GattServiceDescription gattServiceServiceDescription)
        {
            ServiceDescription = gattServiceServiceDescription;
        }

        public GattServiceDescription ServiceDescription { get; }

        public void WithCharacteristic(GattCharacteristicDescription gattCharacteristicDescription)
        {
            ServiceDescription.AddCharacteristic(gattCharacteristicDescription);
        }
    }
}