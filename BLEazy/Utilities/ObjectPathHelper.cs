using System;

namespace BLEazy.Utilities
{
    public static class ObjectPathHelper
    {
        public static string GenerateApplicationObjectPath()
        {
            var appId = Guid.NewGuid().ToString().Substring(0, 8);
            var applicationObjectPath = $"/{appId}";
            return applicationObjectPath;
        }
    }
}