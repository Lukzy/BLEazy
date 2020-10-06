using System.Collections.Generic;
using System.Threading.Tasks;
using BLEazy.BlueZ.Gatt;
using BLEazy.Core;
using BLEazy.Gatt.Descriptions;
using Tmds.DBus;

namespace BLEazy.GattTest
{
    public class GattApplicationManager
    {
        private readonly ServerContext _serverContext;

        public GattApplicationManager(ServerContext serverContext)
        {
            _serverContext = serverContext;
        }

        public async Task RegisterGattApplication(IEnumerable<GattServiceDescription> gattServiceDescriptions)
        {
            var application = await BuildApplicationTree(gattServiceDescriptions);
            await RegisterApplicationInBluez(application.ObjectPath);
        }

        private async Task<GattApplication> BuildApplicationTree(IEnumerable<GattServiceDescription> gattServiceDescriptions)
        {
            var application = await BuildGattApplication();

            foreach (var serviceDescription in gattServiceDescriptions)
            {
                var service = await AddNewService(application, serviceDescription);

                foreach (var characteristicDescription in serviceDescription.GattCharacteristicDescriptions)
                {
                    var characteristic = await AddNewCharacteristic(service, characteristicDescription);

                    foreach (var descriptorDescription in characteristicDescription.Descriptors)
                    {
                        await AddNewDescriptor(characteristic, descriptorDescription);
                    }
                }
            }

            return application;
        }

        private async Task RegisterApplicationInBluez(ObjectPath applicationObjectPath)
        {
            var gattManager = _serverContext.CreateProxy<IGattManager>();
            await gattManager.RegisterApplicationAsync(applicationObjectPath, new Dictionary<string, object>());
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

        private async Task<GattCharacteristic> AddNewCharacteristic(GattService gattService, GattCharacteristicDescription characteristic)
        {
            var gattCharacteristic1Properties = GattPropertiesFactory.CreateGattCharacteristic(characteristic);
            var gattCharacteristic = gattService.AddCharacteristic(gattCharacteristic1Properties, characteristic.CharacteristicSource);
            await _serverContext.RegisterObjectAsync(gattCharacteristic);
            return gattCharacteristic;
        }

        private async Task AddNewDescriptor(GattCharacteristic gattCharacteristic,
            GattDescriptorDescription descriptor)
        {
            var gattDescriptor1Properties = GattPropertiesFactory.CreateGattDescriptor(descriptor);
            var gattDescriptor = gattCharacteristic.AddDescriptor(gattDescriptor1Properties);
            await _serverContext.RegisterObjectAsync(gattDescriptor);
        }
    }
}