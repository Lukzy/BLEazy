using System.Threading.Tasks;

namespace BLEazy.Gatt.Services
{
    public interface ICharacteristicSource
    {
        Task WriteValueAsync(byte[] value);

        Task<byte[]> ReadValueAsync();
    }
}