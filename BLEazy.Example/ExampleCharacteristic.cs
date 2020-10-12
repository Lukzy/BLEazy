using System;
using System.Text;
using System.Threading.Tasks;
using BLEazy.Core;
using BLEazy.Gatt.Sources;

namespace BLEazy.Example
{
    public class ExampleCharacteristic : Characteristic, ICharacteristicSource
    {
        private byte[] _data = Encoding.ASCII.GetBytes("BLEazy!");

        public ExampleCharacteristic()
            : base(new UUID("12345678-1234-5678-1234-56789abcdef1"))
        {
        }

        public Task WriteValueAsync(byte[] value)
        {
            return Task.Run(() =>
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("Writing <");
                stringBuilder.Append(Encoding.ASCII.GetChars(value));
                stringBuilder.Append("> to replace <");
                stringBuilder.Append(Encoding.ASCII.GetChars(_data));
                stringBuilder.Append(">");
                Console.WriteLine(stringBuilder.ToString());

                _data = value;
            });
        }

        public Task<byte[]> ReadValueAsync()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Returning <");
            stringBuilder.Append(Encoding.ASCII.GetChars(_data));
            stringBuilder.Append(">");
            Console.WriteLine(stringBuilder.ToString());

            return Task.FromResult(_data);
        }
    }

    public class Characteristic
    {
        public Characteristic()
            : this(UUID.Generate())
        {
        }

        public Characteristic(UUID uuid)
        {
            UUID = uuid;
        }

        public UUID UUID { get; }
    }
}