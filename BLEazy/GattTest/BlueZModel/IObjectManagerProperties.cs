using System.Collections.Generic;

namespace BLEazy.GattTest.BlueZModel
{
    internal interface IObjectManagerProperties
    {
        IDictionary<string, IDictionary<string, object>> GetProperties();
    }
}