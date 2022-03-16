using VintedProject.Models;

namespace VintedProject.Discounts
{
    public interface IDiscount
    {
        void Process(ShippingTransaction transaction);

        bool Applies(ShippingTransaction transaction, Dictionary<string, List<ProcessedShipping>> processedShippings = null);
    }
}
