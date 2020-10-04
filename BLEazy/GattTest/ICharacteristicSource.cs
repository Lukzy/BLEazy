using System.Threading.Tasks;

namespace BLEazy.GattTest
{
    public interface ICharacteristicSource
    {
        Task WriteValueAsync(byte[] value);
        Task<byte[]> ReadValueAsync();
    }
}