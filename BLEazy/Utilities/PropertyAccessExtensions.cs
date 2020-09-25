using System.Threading.Tasks;

namespace BLEazy.Utilities
{
    public static class PropertyAccessExtensions
    {
        public static T ReadProperty<T>(this object o, string property)
        {
            var propertyValue = o.GetType().GetProperty(property)?.GetValue(o);
            return (T) propertyValue;
        }

        public static object ReadProperty(this object o, string property)
        {
            return o.GetType().GetProperty(property)?.GetValue(o);
        }

        public static Task SetProperty(this object o, string property, object value)
        {
            o.GetType().GetProperty(property)?.SetValue(o, value);
            return Task.CompletedTask;
        }
    }
}