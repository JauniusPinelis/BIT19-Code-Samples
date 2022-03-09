using VintedProject.Interfaces;
using VintedProject.Models;

namespace VintedProject.Services
{


    public class ShippingService
    {
        private List<ShippingTransaction> _shippingTransactions;
        private List<ShippingInfo> _shippingInfos;


        private FileService _fileService;
        private IOutputService _outputService;
        private PriceService _priceService;

        public ShippingService(FileService fileService, IOutputService outputService, PriceService priceService)
        {
            _fileService = fileService;
            _outputService = outputService;
            _priceService = priceService;
        }

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
