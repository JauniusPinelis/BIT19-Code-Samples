namespace VintedProject.Interfaces
{
    public interface ITextImportService
    {
        Task<string[]> ReadShippingInfoText();
        Task<string[]> ReadTransactionsText();
    }
}