using BLEazy.BlueZ.Gatt;
using BLEazy.Gatt;
using BLEazy.GattTest.Description;
using Tmds.DBus;

namespace BLEazy.GattTest
{
    internal class GattPropertiesFactory
    {
        public static GattServiceProperties CreateGattService(GattServiceDescription serviceDescription)
        {
            return new GattServiceProperties
            {
                UUID = serviceDescription.UUID,
                Primary = serviceDescription.Primary,
                Characteristics = new ObjectPath[0]
            };
        }

        public static GattCharacteristicProperties CreateGattCharacteristic(GattCharacteristicDescription characteristic)
        {
            var characteristicProperties = new GattCharacteristicProperties
            {
                UUID = characteristic.UUID,
                Flags = characteristic.Flags
            };

            return characteristicProperties;
        }

        public static GattDescriptorProperties CreateGattDescriptor(GattDescriptorDescription descriptor)
        {
            var descriptorProperties = new GattDescriptorProperties
            {
                UUID = descriptor.UUID,
                Flags = descriptor.Flags,
                Value = descriptor.Value
            };

            return descriptorProperties;
        }
    }
}