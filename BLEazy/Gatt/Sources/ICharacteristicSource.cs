using System.Threading.Tasks;

namespace BLEazy.Gatt.Sources
{
    public interface ICharacteristicSource
    {
        Task WriteValueAsync(byte[] value);

        Task<byte[]> ReadValueAsync();
    }
}