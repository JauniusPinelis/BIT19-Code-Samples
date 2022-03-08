using VintedProject.Models;

namespace VintedProject.Interfaces
{
    public interface IFileService
    {
        Task<List<ShippingInfo>> LoadShippingInfosAsync();
        Task<List<ShippingTransaction>> LoadTransactionsAsync();
    }
}