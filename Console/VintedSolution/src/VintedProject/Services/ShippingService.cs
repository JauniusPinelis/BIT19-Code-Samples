using VintedProject.Discounts;
using VintedProject.Helpers;
using VintedProject.Interfaces;
using VintedProject.Models;

namespace VintedProject.Services
{


    public class ShippingService
    {
        private List<Transaction> _shippingTransactions;
        private List<ShippingInfo> _shippingInfos;

        private ImportService _fileService;
        private IOutputService _outputService;
        private DiscountFactory _discountFactory;

        public ShippingService(ImportService fileService, IOutputService outputService, DiscountFactory discountFactory)
        {
            _fileService = fileService;
            _outputService = outputService;
            _discountFactory = discountFactory;
        }

        public async Task ProcessPricesAsync()
        {
            _shippingTransactions = await _fileService.LoadTransactionsAsync();
            _shippingInfos = await _fileService.LoadShippingInfosAsync();

            foreach (var transaction in _shippingTransactions.Where(st => st.IsValid))
            {
                transaction.Price = PriceHelper.CalculatePrice(transaction, _shippingInfos);

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
