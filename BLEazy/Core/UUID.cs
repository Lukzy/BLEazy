namespace BLEazy.Core
{
    public class UUID
    {
        private readonly string _value;

        public UUID(string value)
        {
            _value = value;
        }

        public static UUID Generate()
        {
            // TODO add real generator
            return new UUID("12345678-1234-5678-1234-56789abcdef0");
        }

        public override string ToString()
        {
            return _value;
        }

        public static implicit operator string(UUID uuid)
        {
            return uuid._value;
        }
    }
}