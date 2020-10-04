using System.Threading.Tasks;
using BLEazy.Core;

namespace BLEazy.Gatt
{
    public class GattManager
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly ServerContext _context;

        public GattManager(ServerContext context)
        {
            _context = context;
        }

        public async Task RegisterApplication(GattApplication application)
        {
            await Task.CompletedTask;
        }
    }
}