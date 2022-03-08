using VintedProject.Models;

namespace VintedProject.Services
{


    public class ShippingService
    {
        private List<ShippingTransaction> _shippingTransactions;
        private List<ShippingInfo> _shippingInfos;


        private FileService _fileService;
        private OutputService _outputService;
        private PriceService _priceService;

        public async Task ProcessPricesAsync()
        {
            _shippingTransactions = await _fileService.LoadTransactionsAsync();
            _shippingInfos = await _fileService.LoadShippingInfosAsync();

            foreach (var transaction in _shippingTransactions)
            {
                transaction.Price = _priceService.CalculatePrice(transaction, _shippingInfos);
            }

            _outputService.PrintTransactions(_shippingTransactions);
        }
    }
}
