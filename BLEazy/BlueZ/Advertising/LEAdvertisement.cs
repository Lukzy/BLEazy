using System;
using System.Threading.Tasks;
using BLEazy.Core;

namespace BLEazy.BlueZ.Advertising
{
    public class LEAdvertisement : PropertiesBase<LEAdvertisementProperties>, ILEAdvertisement
    {
        public LEAdvertisement(string objectPath, LEAdvertisementProperties properties) : base(objectPath, properties)
        {
        }
        
        public Task ReleaseAsync()
        {
            throw new NotImplementedException();
        }
    }
}