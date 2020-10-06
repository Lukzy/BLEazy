using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLEazy.GattTest;
using BLEazy.Utilities;
using Tmds.DBus;

namespace BLEazy.BlueZ.Gatt
{
    internal class GattCharacteristic : PropertiesBase<GattCharacteristicProperties>, IGattCharacteristic, IObjectManagerProperties
    {
        private readonly ICharacteristicSource _characteristicSource;

        public GattCharacteristic(ObjectPath objectPath, GattCharacteristicProperties properties, ICharacteristicSource characteristicSource) : base(objectPath, properties)
        {
            _characteristicSource = characteristicSource;
        }

        public IList<GattDescriptor> Descriptors { get; } = new List<GattDescriptor>();

        public Task<byte[]> ReadValueAsync(IDictionary<string, object> options)
        {
            return _characteristicSource.ReadValueAsync();
        }

        public Task WriteValueAsync(byte[] value, IDictionary<string, object> options)
        {
            return _characteristicSource.WriteValueAsync(value);
        }

        public Task StartNotifyAsync()
        {
            throw new NotImplementedException();
        }

        public Task StopNotifyAsync()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, IDictionary<string, object>> GetProperties()
        {
            // TODO try to extract
            return new Dictionary<string, IDictionary<string, object>>
            {
                {
                    "org.bluez.GattCharacteristic1", new Dictionary<string, object>
                    {
                        {
                            "Service", Properties.Service
                        },
                        {
                            "UUID", Properties.UUID
                        },
                        {
                            "Flags", Properties.Flags
                        },
                        {
                            "Descriptors", Descriptors.Select(d => d.ObjectPath).ToArray()
                        }
                    }
                }
            };
        }

        public GattDescriptor AddDescriptor(GattDescriptorProperties gattDescriptorProperties)
        {
            // TODO adapt to new mechanism
            gattDescriptorProperties.Characteristic = ObjectPath;
            var gattDescriptor = new GattDescriptor(NextDescriptorPath(), gattDescriptorProperties);
            Descriptors.Add(gattDescriptor);
            return gattDescriptor;
        }

        private ObjectPath NextDescriptorPath()
        {
            return ObjectPath + "/descriptor" + Descriptors.Count;
        }
    }
}