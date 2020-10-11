using BLEazy.BlueZ.Gatt;
using BLEazy.Gatt.Descriptions;
using Tmds.DBus;

namespace BLEazy.Gatt
{
    internal class GattPropertiesFactory
    {
        //TODO refactor factories and use a mapper instead

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