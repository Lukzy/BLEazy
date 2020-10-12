using System.Collections.Generic;
using System.Linq;
using BLEazy.Gatt.Services;
using BLEazy.Utilities;

namespace BLEazy.BlueZ.Gatt
{
    internal class GattService : PropertiesBase<GattServiceProperties>, IGattService, IObjectManagerProperties
    {
        private readonly IList<GattCharacteristic> _characteristics = new List<GattCharacteristic>();

        public GattService(string objectPath, GattServiceProperties properties) : base(objectPath, properties)
        {
        }

        public IEnumerable<GattCharacteristic> Characteristics => _characteristics;

        public IDictionary<string, IDictionary<string, object>> GetProperties()
        {
            // TODO try to extract
            return new Dictionary<string, IDictionary<string, object>>
            {
                {
                    "org.bluez.GattService1", new Dictionary<string, object>
                    {
                        {
                            "UUID", Properties.UUID
                        },
                        {
                            "Primary", Properties.Primary
                        },
                        {
                            "Characteristics", Characteristics.Select(c => c.ObjectPath).ToArray()
                        }
                    }
                }
            };
        }

        public GattCharacteristic AddCharacteristic(GattCharacteristicProperties characteristicProperties, ICharacteristicSource characteristicSource)
        {
            // TODO adapt to new mechanism
            characteristicProperties.Service = ObjectPath;
            var gattCharacteristic = new GattCharacteristic(NextCharacteristicPath(), characteristicProperties, characteristicSource);
            _characteristics.Add(gattCharacteristic);
            Properties.Characteristics = Properties.Characteristics.Append(NextCharacteristicPath()).ToArray();
            return gattCharacteristic;
        }

        private string NextCharacteristicPath()
        {
            return ObjectPath + "/characteristic" + _characteristics.Count;
        }
    }
}