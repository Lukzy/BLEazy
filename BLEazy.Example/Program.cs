using System;

namespace BLEazy.Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("BLEazy Example");

            var bluetoothManager = new BluetoothManager();
            bluetoothManager.Test();
        }
    }
}