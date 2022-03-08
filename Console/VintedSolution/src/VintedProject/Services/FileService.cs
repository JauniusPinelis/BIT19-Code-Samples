using VintedProject.Interfaces;
using VintedProject.Models;

namespace VintedProject.Services
{
    public class FileService : IFileService
    {
        private ITextImportService _textImportService;

        public FileService(ITextImportService textImportService)
        {
            _textImportService = textImportService;
        }

        public async Task<List<ShippingTransaction>> LoadTransactionsAsync()
        {
            var transactionLines = await _textImportService.ReadTransactionsText();

            var transactions = new List<ShippingTransaction>();

            foreach (var transactionLine in transactionLines)
            {
                try
                {
                    var transactionInfo = transactionLine.Split(" ");

                    var transaction = new ShippingTransaction
                    {
                        Date = DateOnly.Parse(transactionInfo[0]),
                        PackageSize = transactionInfo[1],
                        Provider = transactionInfo[2]
                    };

                    transactions.Add(transaction);
                }
                catch
                {
                    transactions.Add(new ShippingTransaction
                    {
                        IsValid = false
                    });
                }
            }

            return transactions;
        }

        public async Task<List<ShippingInfo>> LoadShippingInfosAsync()
        {
            var shippingInfoLines = await _textImportService.ReadShippingInfoText();

            var shippingInfos = new List<ShippingInfo>();

            foreach (string info in shippingInfoLines)
            {
                var splitInfo = info.Split(" ");

                shippingInfos.Add(new ShippingInfo
                {
                    Provider = splitInfo[0],
                    PackageSize = splitInfo[1],
                    Price = decimal.Parse(splitInfo[2])
                });
            }

            return shippingInfos;
        }
    }
}
