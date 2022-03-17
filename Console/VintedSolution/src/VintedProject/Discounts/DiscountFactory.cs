using VintedProject.Discounts.Strategies;
using VintedProject.Helpers;
using VintedProject.Models;

namespace VintedProject.Discounts
{
    public class DiscountFactory
    {
        private Dictionary<string, List<ProcessedShipping>> _processedShippings = new Dictionary<string, List<ProcessedShipping>>();

        public IDiscount Build(Transaction transaction, List<ShippingInfo> shippingInfos)
        {
            // FactoryPattern
            var discountList = new List<IDiscount>() {
                new FreeShippingDiscount(_processedShippings),
                new LowestSmallPackageDiscount(shippingInfos, _processedShippings)
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

        public void RecordProcessedTransaction(Transaction transaction)
        {
            var key = TransactionHelper.GenerateKey(transaction);

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
