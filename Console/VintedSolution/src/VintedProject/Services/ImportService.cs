using VintedProject.Enums;
using VintedProject.Extensions;
using VintedProject.Interfaces;
using VintedProject.Models;

namespace VintedProject.Services
{
    public class ImportService
    {
        private ITextImportService _textImportService;

        public ImportService(ITextImportService textImportService)
        {
            _textImportService = textImportService;
        }

        public async Task<List<Transaction>> LoadTransactionsAsync()
        {
            var transactionLines = await _textImportService.ReadTransactionsText();

            var transactions = new List<Transaction>();

            foreach (var transactionLine in transactionLines)
            {
                try
                {
                    var transactionInfo = transactionLine.Split(" ");

                    var transaction = new Transaction
                    {
                        Date = DateOnly.Parse(transactionInfo[0]),
                        PackageSize = transactionInfo[1].ToEnum<PackageSize>(),
                        Provider = transactionInfo[2].ToEnum<ShippingProvider>()
                    };

                    transactions.Add(transaction);
                }
                catch
                {
                    transactions.Add(new Transaction
                    {
                        IsValid = false,
                        ParametersText = transactionLine
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

                    Provider = splitInfo[0].ToEnum<ShippingProvider>(),
                    PackageSize = splitInfo[1].ToEnum<PackageSize>(),
                    Price = decimal.Parse(splitInfo[2])
                });
            }

            return shippingInfos;
        }
    }
}
