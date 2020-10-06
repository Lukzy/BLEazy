namespace BLEazy.Gatt.Descriptions
{
    public class GattDescriptorDescription : GattDescription
    {
        public byte[] Value { get; set; }

        public string[] Flags { get; set; }
    }
}