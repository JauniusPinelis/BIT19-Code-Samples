using VintedProject.Helpers;
using VintedProject.Models;

namespace VintedProject.Discounts.Strategies
{
    public class DiscountBase
    {
        private const decimal discountLimit = 10M;

        protected Dictionary<string, List<ProcessedShipping>> _processedShippings;

        public DiscountBase(Dictionary<string, List<ProcessedShipping>> processedShippings)
        {
            _processedShippings = processedShippings;
        }

        protected void LimitDiscount(Transaction transaction)
        {
            var key = TransactionHelper.GenerateKey(transaction);

            var processedShippings = _processedShippings.GetValueOrDefault(key, new List<ProcessedShipping>());
            var accumulatedDiscounts = processedShippings.Sum(ps => ps.Discount);

            if (accumulatedDiscounts + transaction.Discount > discountLimit)
            {
                var previousDiscount = transaction.Discount;
                transaction.Discount = discountLimit - accumulatedDiscounts;
                transaction.Price += previousDiscount - transaction.Discount;
            }
        }
    }
}
