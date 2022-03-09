using VintedProject.Services;

namespace VintedProject
{
    public class Executor
    {
        private readonly ShippingService _shippingService;

        public Executor(ShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        public async Task ExecuteAsync()
        {
            await _shippingService.ProcessPricesAsync();
        }
    }
}
