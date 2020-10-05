using System.Collections.Generic;
using System.Threading.Tasks;
using BLEazy.BlueZ.Gatt;
using BLEazy.Utilities;
using Tmds.DBus;

namespace BLEazy.GattTest.BlueZModel
{
    internal class GattDescriptor : PropertiesBase<GattDescriptorProperties>, IGattDescriptor, IObjectManagerProperties
    {
        public GattDescriptor(ObjectPath objectPath, GattDescriptorProperties gattDescriptorProperties)
            : base(objectPath, gattDescriptorProperties)
        {
        }

        public Task<byte[]> ReadValueAsync()
        {
            return Task.FromResult(Properties.Value);
        }

        public IDictionary<string, IDictionary<string, object>> GetProperties()
        {
            return new Dictionary<string, IDictionary<string, object>>
            {
                {
                    "org.bluez.GattDescriptor1", new Dictionary<string, object>
                    {
                        {
                            "Characteristic", Properties.Characteristic
                        },
                        {
                            "UUID", Properties.UUID
                        },
                        {
                            "Flags", Properties.Flags
                        }
                    }
                }
            };
        }
    }
}