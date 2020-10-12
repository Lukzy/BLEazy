using System;
using System.Threading.Tasks;
using Tmds.DBus;

namespace BLEazy.Utilities
{
    public abstract class PropertiesBase<TV>
    {
        protected readonly TV Properties;

        protected PropertiesBase(ObjectPath objectPath, TV properties)
        {
            ObjectPath = objectPath;
            Properties = properties;
        }

        public ObjectPath ObjectPath { get; }

        public Task<object> GetAsync(string property)
        {
            return Task.FromResult(Properties.ReadProperty(property));
        }

        public Task<T> GetAsync<T>(string property)
        {
            return Task.FromResult(Properties.ReadProperty<T>(property));
        }

        public Task<TV> GetAllAsync()
        {
            return Task.FromResult(Properties);
        }

        public Task SetAsync(string property, object value)
        {
            return Properties.SetProperty(property, value);
        }

        public Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler)
        {
            return SignalWatcher.AddAsync(this, nameof(OnPropertiesChanged), handler);
        }

        public event Action<PropertyChanges> OnPropertiesChanged;
    }
}