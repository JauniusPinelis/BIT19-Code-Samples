using VintedProject.Models;

namespace VintedProject.Discounts.Strategies
{
    public class FreeShippingDiscount : IDiscount
    {
        public bool Applies(ShippingTransaction transaction, Dictionary<string, List<ProcessedShipping>> processedShippings)
        {
            var key = $"{transaction.Date.Year}-{transaction.Date.Month}";
            List<ProcessedShipping> transactions = processedShippings.GetValueOrDefault(key, new List<ProcessedShipping>());

            return transaction.PackageSize == Enums.PackageSize.L &&
                transaction.Provider == Enums.ShippingProvider.LP &&
                transactions.Count(t => t.Size == Enums.PackageSize.L && t.Provider == Enums.ShippingProvider.LP) == 2;
        }

        public void Process(ShippingTransaction transaction)
        {
            var discount = transaction.Price.Value;

            transaction.Price = 0;
            transaction.Discount = discount;
        }
    }
}
