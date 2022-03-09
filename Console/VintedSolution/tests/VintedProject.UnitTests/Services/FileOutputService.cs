using System.Collections.Generic;
using System.IO;
using System.Linq;
using VintedProject.Interfaces;
using VintedProject.Models;

namespace VintedProject.UnitTests.Services
{
    public class FileOutputService : IOutputService
    {
        public void PrintTransactions(List<ShippingTransaction> transactions)
        {
            File.WriteAllLines("Data/Output.txt", transactions.Select(t => t.ToString()));
        }
    }
}
