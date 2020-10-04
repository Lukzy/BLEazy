using System.Collections.Generic;
using System.Linq;
using BLEazy.Utilities;

namespace BLEazy.GattTest.BlueZModel
{
    internal class GattService : PropertiesBase<GattService1Properties>, IGattService1, IObjectManagerProperties
    {
        private readonly IList<GattCharacteristic> _characteristics = new List<GattCharacteristic>();

        public GattService(string objectPath, GattService1Properties properties) : base(objectPath, properties)
        {
        }

        public IEnumerable<GattCharacteristic> Characteristics => _characteristics;

        public IDictionary<string, IDictionary<string, object>> GetProperties()
        {
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

        public GattCharacteristic AddCharacteristic(GattCharacteristic1Properties characteristic, ICharacteristicSource characteristicSource)
        {
            characteristic.Service = ObjectPath;
            var gattCharacteristic = new GattCharacteristic(NextCharacteristicPath(), characteristic, characteristicSource);
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