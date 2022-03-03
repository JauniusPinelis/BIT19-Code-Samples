using VintedProject.Models;

namespace VintedProject.Interfaces
{
    public interface IFileService
    {
        List<ShippingInfo> LoadShippingInfos();
        List<ShippingTransaction> LoadTransactions();
    }
}