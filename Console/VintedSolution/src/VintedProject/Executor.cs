using VintedProject.Services;

namespace VintedProject
{
    public class Executor
    {
        private ShippingService _shippingService;

        public async Task ExecuteAsync()
        {
            await _shippingService.ProcessPricesAsync();
        }
    }
}
