using VintedProject.Helpers;
using VintedProject.Models;

namespace VintedProject.Discounts.Strategies
{
    public class FreeShippingDiscount : DiscountBase, IDiscount
    {
        public FreeShippingDiscount(Dictionary<string, List<ProcessedShipping>> processedShippings) : base(processedShippings)
        {

        }

        public bool Applies(Transaction transaction, Dictionary<string, List<ProcessedShipping>> processedShippings)
        {
            var key = TransactionHelper.GenerateKey(transaction);
            List<ProcessedShipping> transactions = processedShippings.GetValueOrDefault(key, new List<ProcessedShipping>());

            return transaction.PackageSize == Enums.PackageSize.L &&
                transaction.Provider == Enums.ShippingProvider.LP &&
                transactions.Count(t => t.Size == Enums.PackageSize.L && t.Provider == Enums.ShippingProvider.LP) == 2;
        }

        public void Process(Transaction transaction)
        {
            var discount = transaction.Price.Value;

            transaction.Price = 0;
            transaction.Discount = discount;

            LimitDiscount(transaction);
        }
    }
}
