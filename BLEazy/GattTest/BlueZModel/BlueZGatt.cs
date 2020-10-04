using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.GattTest.BlueZModel
{
    [DBusInterface("org.bluez.GattService1")]
    internal interface IGattService1 : IDBusObject
    {
        Task<object> GetAsync(string prop);
        Task<GattService1Properties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    internal class GattService1Properties
    {
        public string UUID { get; set; }

        public bool Primary { get; set; }

        public ObjectPath[] Characteristics { get; set; }
    }

    [DBusInterface("org.bluez.GattCharacteristic1")]
    internal interface IGattCharacteristic1 : IDBusObject
    {
        Task<byte[]> ReadValueAsync(IDictionary<string, object> options);
        Task WriteValueAsync(byte[] value, IDictionary<string, object> options);
        Task StartNotifyAsync();
        Task StopNotifyAsync();
        Task<object> GetAsync(string prop);
        Task<GattCharacteristic1Properties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    public class GattCharacteristic1Properties
    {
        public string UUID { get; set; }

        public ObjectPath Service { get; set; }

        public byte[] Value { get; set; } = default;

        public bool Notifying { get; set; } = default;

        public string[] Flags { get; set; }
    }

    [DBusInterface("org.bluez.GattDescriptor1")]
    internal interface IGattDescriptor1 : IDBusObject
    {
        Task<byte[]> ReadValueAsync();
        Task<object> GetAsync(string prop);
        Task<GattDescriptor1Properties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    public class GattDescriptor1Properties
    {
        public string UUID { get; set; }

        public ObjectPath Characteristic { get; set; }

        public byte[] Value { get; set; }

        public string[] Flags { get; set; }
    }

    [DBusInterface("org.bluez.LEAdvertisement1")]
    internal interface ILEAdvertisement1 : IDBusObject
    {
        Task ReleaseAsync();
        Task<T> GetAsync<T>(string prop);
        Task<LEAdvertisement1Properties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    internal class LEAdvertisement1Properties
    {
        public string Type { get; set; } = default;

        public string[] ServiceUUIDs { get; set; } = default;

        public IDictionary<string, object> ManufacturerData { get; set; } = default;

        public string[] SolicitUUIDs { get; set; } = default;

        public IDictionary<string, object> ServiceData { get; set; } = default;

        public bool IncludeTxPower { get; set; } = default;
    }

    internal static class LEAdvertisement1Extensions
    {
        public static Task<string> GetTypeAsync(this ILEAdvertisement1 o)
        {
            return o.GetAsync<string>("Type");
        }

        public static Task<string[]> GetServiceUUIDsAsync(this ILEAdvertisement1 o)
        {
            return o.GetAsync<string[]>("ServiceUUIDs");
        }

        public static Task<IDictionary<string, object>> GetManufacturerDataAsync(this ILEAdvertisement1 o)
        {
            return o.GetAsync<IDictionary<string, object>>("ManufacturerData");
        }

        public static Task<string[]> GetSolicitUUIDsAsync(this ILEAdvertisement1 o)
        {
            return o.GetAsync<string[]>("SolicitUUIDs");
        }

        public static Task<IDictionary<string, object>> GetServiceDataAsync(this ILEAdvertisement1 o)
        {
            return o.GetAsync<IDictionary<string, object>>("ServiceData");
        }

        public static Task<bool> GetIncludeTxPowerAsync(this ILEAdvertisement1 o)
        {
            return o.GetAsync<bool>("IncludeTxPower");
        }
    }
}