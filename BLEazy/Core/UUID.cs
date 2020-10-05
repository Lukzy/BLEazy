namespace BLEazy.Core
{
    public class UUID
    {
        private readonly string _value;

        public UUID(string value)
        {
            _value = value;
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