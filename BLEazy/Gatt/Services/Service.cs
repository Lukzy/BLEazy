using System.Collections.Generic;
using BLEazy.Core;
using BLEazy.Gatt.Sources;

namespace BLEazy.Gatt.Services
{
    public class Service
    {
        public Service()
            : this(UUID.Generate(), true)
        {
        }

        public Service(UUID uuid, bool isPrimary)
        {
            UUID = uuid;
            IsPrimary = isPrimary;
        }

        public Service(UUID uuid, bool isPrimary, IList<ICharacteristicSource> characteristics)
        {
            UUID = uuid;
            IsPrimary = isPrimary;
            Characteristics = characteristics;
        }

        public UUID UUID { get; }

        public bool IsPrimary { get; }

        public IList<ICharacteristicSource> Characteristics { get; } = new List<ICharacteristicSource>();
    }
}