using VintedProject.Services;

namespace VintedProject
{
    public class Executor
    {
        private ShippingService _shippingService;

        public void Execute()
        {
            _shippingService.ProcessPrices();
        }
    }
}
