using VintedProject.Models;

namespace VintedProject.Services
{


    public class ShippingService
    {
        private List<ShippingTransaction> _shippingTransactions;

        private FileService _fileService;
        private OutputService _outputService;
        private PriceService _priceService;

        public void ProcessPrices()
        {
            _shippingTransactions = _fileService.LoadTransactions();

            foreach (var transaction in _shippingTransactions)
            {
                transaction.Price = _priceService.CalculatePrice(transaction);
            }

            _outputService.PrintTransactions(_shippingTransactions);
        }
    }
}
