using System.Collections.Generic;
using System.Threading.Tasks;
using Tmds.DBus;

namespace BLEazy.GattTest.BlueZModel
{
    [DBusInterface("org.freedesktop.DBus.ObjectManager")]
    internal class GattApplication : IObjectManager
    {
        private readonly IList<GattService> _services = new List<GattService>();

        public GattApplication(ObjectPath objectPath)
        {
            ObjectPath = objectPath;
        }

        public ObjectPath ObjectPath { get; }

        public Task<IDictionary<ObjectPath, IDictionary<string, IDictionary<string, object>>>> GetManagedObjectsAsync()
        {
            IDictionary<ObjectPath, IDictionary<string, IDictionary<string, object>>> result =
                new Dictionary<ObjectPath, IDictionary<string, IDictionary<string, object>>>();
            foreach (var service in _services)
            {
                result[service.ObjectPath] = service.GetProperties();
                foreach (var characteristic in service.Characteristics)
                {
                    result[characteristic.ObjectPath] = characteristic.GetProperties();
                    foreach (var descriptor in characteristic.Descriptors)
                    {
                        result[descriptor.ObjectPath] = descriptor.GetProperties();
                    }
                }
            }

            return Task.FromResult(result);
        }

        public GattService AddService(GattService1Properties gattService)
        {
            var servicePath = ObjectPath + "/service" + _services.Count;
            var service = new GattService(servicePath, gattService);
            _services.Add(service);
            return service;
        }
    }
}