using System.Threading.Tasks;
using BLEazy.Core;

namespace BLEazy.Gatt.Services
{
    public abstract class Characteristic : ICharacteristicSource
    {
        protected Characteristic()
            : this(UUID.Generate())
        {
        }

        protected Characteristic(UUID uuid)
        {
            UUID = uuid;
        }

        public UUID UUID { get; }

        public abstract Task WriteValueAsync(byte[] value);

        public abstract Task<byte[]> ReadValueAsync();
    }
}