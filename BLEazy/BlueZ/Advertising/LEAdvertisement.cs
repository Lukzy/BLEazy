using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BLEazy.Utilities;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Advertising
{
    internal class LEAdvertisement : PropertiesBase<LEAdvertisementProperties>, ILEAdvertisement
    {
        public LEAdvertisement(string objectPath, LEAdvertisementProperties properties) : base(objectPath, properties)
        {
        }

        public async Task ReleaseAsync()
        {
            await Task.CompletedTask;
        }
    }
}