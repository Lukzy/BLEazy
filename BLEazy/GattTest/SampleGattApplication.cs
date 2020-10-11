using System.Collections.Generic;
using BLEazy.Core;
using BLEazy.Gatt.Descriptions;

namespace BLEazy.GattTest
{
    public class SampleGattApplication
    {
        public static IEnumerable<GattServiceDescription> BuildServiceDescriptions()
        {
            var gattServiceDescription = new GattServiceDescription
            {
                UUID = new UUID("12345678-1234-5678-1234-56789abcdef0"),
                Primary = true
            };

            var gattCharacteristicDescription = new GattCharacteristicDescription
            {
                CharacteristicSource = new ExampleCharacteristicSource(),
                UUID = new UUID("12345678-1234-5678-1234-56789abcdef1"),
                Flags = new[]
                {
                    "read", "write", "writable-auxiliaries"
                }
            };
            var gattDescriptorDescription = new GattDescriptorDescription
            {
                Value = new[]
                {
                    (byte) 't'
                },
                UUID = new UUID("12345678-1234-5678-1234-56789abcdef2"),
                Flags = new[]
                {
                    "read", "write"
                }
            };

            var gab = new GattApplicationBuilder();
            gab
                .AddService(gattServiceDescription)
                .WithCharacteristic(gattCharacteristicDescription, new[]
                {
                    gattDescriptorDescription
                });

            return gab.BuildServiceDescriptions();
        }
    }
}