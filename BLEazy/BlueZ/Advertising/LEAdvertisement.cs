﻿using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BLEazy.Core;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Connection.DynamicAssemblyName)]

namespace BLEazy.BlueZ.Advertising
{
    internal class LEAdvertisement : PropertiesBase<LEAdvertisementProperties>, ILEAdvertisement
    {
        public LEAdvertisement(string objectPath, LEAdvertisementProperties properties) : base(objectPath, properties)
        {
        }

        public Task ReleaseAsync()
        {
            throw new NotImplementedException();
        }
    }
}