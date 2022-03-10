using VintedProject.Models;

namespace VintedProject.Discounts
{
    public interface IDiscount
    {
        void Process(ShippingTransaction transaction);
    }
}
