using BLEazy.BlueZ.Gatt;
using BLEazy.Gatt.Services;
using Tmds.DBus;

namespace BLEazy.Gatt
{
    internal class GattPropertiesFactory
    {
        //TODO refactor factories and use a mapper instead

        public static GattServiceProperties CreateGattService(Service service)
        {
            return new GattServiceProperties
            {
                UUID = service.UUID,
                Primary = service.IsPrimary,
                Characteristics = new ObjectPath[0]
            };
        }

        public static GattCharacteristicProperties CreateGattCharacteristic(Characteristic characteristic)
        {
            var characteristicProperties = new GattCharacteristicProperties
            {
                UUID = characteristic.UUID,
                Flags = new[] {"read", "write"}
            };

            return characteristicProperties;
        }
    }
}