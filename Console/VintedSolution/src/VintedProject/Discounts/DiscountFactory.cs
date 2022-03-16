using VintedProject.Discounts.Strategies;
using VintedProject.Models;

namespace VintedProject.Discounts
{
    public class DiscountFactory
    {
        private Dictionary<string, List<ProcessedShipping>> _processedShippings = new Dictionary<string, List<ProcessedShipping>>();

        public IDiscount Build(ShippingTransaction transaction, List<ShippingInfo> shippingInfos)
        {
            var key = $"{transaction.Date.Year}-{transaction.Date.Month}";
            List<ProcessedShipping> transactions = _processedShippings.GetValueOrDefault(key, new List<ProcessedShipping>());

            if (transaction.PackageSize == Enums.PackageSize.L &&
                transaction.Provider == Enums.ShippingProvider.LP &&
                transactions.Count(t => t.Size == Enums.PackageSize.L && t.Provider == Enums.ShippingProvider.LP) == 2)

            {
                return new FreeShippingDiscount();
            }
            // Logic which will decide which discount to pick
            if (transaction.PackageSize == Enums.PackageSize.S)
            {
                return new LowestSmallPackageDiscount(shippingInfos);
            }

            return null;
        }

        public void RecordProcessedTransaction(ShippingTransaction transaction)
        {
            var key = $"{transaction.Date.Year}-{transaction.Date.Month}";

            List<ProcessedShipping> shippings = _processedShippings.GetValueOrDefault(key, new List<ProcessedShipping>());
            shippings.Add(new ProcessedShipping
            {
                Discount = transaction.Discount,
                Provider = transaction.Provider,
                Size = transaction.PackageSize
            });

            _processedShippings[key] = shippings;
        }
    }
}
