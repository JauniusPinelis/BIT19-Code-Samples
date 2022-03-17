using VintedProject.Models;

namespace VintedProject.Discounts
{
    public interface IDiscount
    {
        void Process(Transaction transaction);

        bool Applies(Transaction transaction, Dictionary<string, List<ProcessedShipping>> processedShippings = null);
    }
}
