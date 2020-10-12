using System.Collections.Generic;
using System.Threading.Tasks;
using BLEazy.BlueZ.Gatt;
using BLEazy.Core;
using BLEazy.Gatt.Descriptions;

namespace BLEazy.Gatt
{
    public class GattApplicationManager
    {
        //TODO refactor application build process

        private readonly ServerContext _serverContext;

        public GattApplicationManager(ServerContext serverContext)
        {
            _serverContext = serverContext;
        }

        internal async Task<GattApplication> BuildApplicationTree(IEnumerable<GattServiceDescription> gattServiceDescriptions)
        {
            var application = await BuildGattApplication();

            foreach (var serviceDescription in gattServiceDescriptions)
            {
                var service = await AddNewService(application, serviceDescription);

                foreach (var characteristicDescription in serviceDescription.GattCharacteristicDescriptions)
                {
                    await AddNewCharacteristic(service, characteristicDescription);
                }
            }

            return application;
        }

        private async Task<GattApplication> BuildGattApplication()
        {
            var application = new GattApplication();
            await _serverContext.RegisterObjectAsync(application);
            return application;
        }

        private async Task<GattService> AddNewService(GattApplication application,
            GattServiceDescription serviceDescription)
        {
            var gattServiceProperties = GattPropertiesFactory.CreateGattService(serviceDescription);
            var gattService = application.AddService(gattServiceProperties);
            await _serverContext.RegisterObjectAsync(gattService);
            return gattService;
        }

        private async Task AddNewCharacteristic(GattService gattService, GattCharacteristicDescription characteristic)
        {
            var gattCharacteristicProperties = GattPropertiesFactory.CreateGattCharacteristic(characteristic);
            var gattCharacteristic = gattService.AddCharacteristic(gattCharacteristicProperties, characteristic.CharacteristicSource);
            await _serverContext.RegisterObjectAsync(gattCharacteristic);
        }
    }
}