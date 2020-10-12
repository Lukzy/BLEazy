using System.Collections.Generic;

namespace BLEazy.BlueZ
{
    internal interface IObjectManagerProperties
    {
        IDictionary<string, IDictionary<string, object>> GetProperties();
    }
}