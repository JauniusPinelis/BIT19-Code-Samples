using VintedProject.Models;

namespace VintedProject.Discounts.Strategies
{
    public class DiscountBase
    {
        protected Dictionary<string, List<ProcessedShipping>> _processedShippings;

        public DiscountBase(Dictionary<string, List<ProcessedShipping>> processedShippings)
        {
            _processedShippings = processedShippings;
        }

        protected void LimitDiscount(ShippingTransaction transaction)
        {
            var discountLimit = 10M;
            var key = $"{transaction.Date.Year}-{transaction.Date.Month}";

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
