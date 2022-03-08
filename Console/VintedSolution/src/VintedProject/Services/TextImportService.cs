using VintedProject.Interfaces;

namespace VintedProject.Services
{
    public class TextImportService : ITextImportService
    {
        public async Task<string[]> ReadShippingInfoText()
        {
            return await File.ReadAllLinesAsync("/Data/ShippingPrices.txt");
        }

        public async Task<string[]> ReadTransactionsText()
        {
            return await File.ReadAllLinesAsync("/Data/Transactions.txt");
        }
    }
}