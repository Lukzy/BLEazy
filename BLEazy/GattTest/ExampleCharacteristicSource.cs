using System;
using System.Text;
using System.Threading.Tasks;
using BLEazy.Gatt.Sources;

namespace BLEazy.GattTest
{
    internal class ExampleCharacteristicSource : ICharacteristicSource
    {
        private byte[] _data = Encoding.ASCII.GetBytes("BLEazy!");

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
}