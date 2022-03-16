using VintedProject.Models;

namespace VintedProject.Discounts.Strategies
{
    public class FreeShippingDiscount : IDiscount
    {
        public void Process(ShippingTransaction transaction)
        {
            var discount = transaction.Price.Value;

            transaction.Price = 0;
            transaction.Discount = discount;
        }
    }
}
