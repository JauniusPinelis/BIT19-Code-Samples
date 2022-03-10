using VintedProject.Discounts;
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
        private DiscountFactory _discountFactory;

        public ShippingService(FileService fileService, IOutputService outputService,
            PriceService priceService, DiscountFactory discountFactory)
        {
            _fileService = fileService;
            _outputService = outputService;
            _priceService = priceService;
            _discountFactory = discountFactory;
        }

        public async Task ProcessPricesAsync()
        {
            _shippingTransactions = await _fileService.LoadTransactionsAsync();
            _shippingInfos = await _fileService.LoadShippingInfosAsync();

            foreach (var transaction in _shippingTransactions)
            {
                transaction.Price = _priceService.CalculatePrice(transaction, _shippingInfos);

                IDiscount discount = _discountFactory.Build(transaction, _shippingInfos);

                if (discount != null)
                {
                    discount.Process(transaction);
                }
                _discountFactory.RecordProcessedTransaction(transaction);
            }

            _outputService.PrintTransactions(_shippingTransactions);
        }
    }
}
