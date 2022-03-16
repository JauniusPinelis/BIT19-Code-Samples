using VintedProject.Discounts.Strategies;
using VintedProject.Models;

namespace VintedProject.Discounts
{
    public class DiscountFactory
    {
        private Dictionary<string, List<ProcessedShipping>> _processedShippings = new Dictionary<string, List<ProcessedShipping>>();

        public IDiscount Build(ShippingTransaction transaction, List<ShippingInfo> shippingInfos)
        {

            var discountList = new List<IDiscount>() {
                new FreeShippingDiscount(),
                new LowestSmallPackageDiscount(shippingInfos)
            };

            foreach (var discount in discountList)
            {
                if (discount.Applies(transaction, _processedShippings))
                {
                    return discount;
                }
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
