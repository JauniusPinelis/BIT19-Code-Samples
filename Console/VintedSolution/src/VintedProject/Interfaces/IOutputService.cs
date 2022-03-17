using VintedProject.Models;

namespace VintedProject.Interfaces
{
    public interface IOutputService
    {
        void PrintTransactions(List<Transaction> transactions);
    }
}