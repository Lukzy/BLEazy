﻿using System;
using System.Text;
using System.Threading.Tasks;
using BLEazy.Core;
using BLEazy.Gatt;
using BLEazy.GattTest.Description;

namespace BLEazy.GattTest
{
    public class SampleGattApplication
    {
        public static async Task RegisterGattApplication(ServerContext serverContext)
        {
            var gattServiceDescription = new GattServiceDescription
            {
                UUID = new UUID("12345678-1234-5678-1234-56789abcdef0"),
                Primary = true
            };

            var gattCharacteristicDescription = new GattCharacteristicDescription
            {
                CharacteristicSource = new ExampleCharacteristicSource(),
                UUID = "12345678-1234-5678-1234-56789abcdef1",
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
                UUID = "12345678-1234-5678-1234-56789abcdef2",
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

            await new GattApplicationManager(serverContext).RegisterGattApplication(gab.BuildServiceDescriptions());
        }

        internal class ExampleCharacteristicSource : ICharacteristicSource
        {
            public Task WriteValueAsync(byte[] value)
            {
                Console.WriteLine("Writing value");
                return Task.Run(() => Console.WriteLine(Encoding.ASCII.GetChars(value)));
            }

            public Task<byte[]> ReadValueAsync()
            {
                Console.WriteLine("Reading value");
                return Task.FromResult(Encoding.ASCII.GetBytes("Hello BLE"));
            }
        }
    }
}