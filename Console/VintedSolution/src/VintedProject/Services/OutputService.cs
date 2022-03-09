using VintedProject.Interfaces;
using VintedProject.Models;

namespace VintedProject.Services
{
    public class OutputService : IOutputService
    {
        public void PrintTransactions(List<ShippingTransaction> transactions)
        {
            transactions.ForEach(transaction => Console.WriteLine(transaction));
        }
    }
}
