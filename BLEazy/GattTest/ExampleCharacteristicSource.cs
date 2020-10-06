using System;
using System.Text;
using System.Threading.Tasks;
using BLEazy.Gatt.Sources;

namespace BLEazy.GattTest
{
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