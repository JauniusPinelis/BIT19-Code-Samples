using VintedProject.Models;

namespace VintedProject.Helpers
{
    public static class TransactionHelper
    {
        public static string GenerateKey(Transaction transaction)
        {
            return $"{transaction.Date.Year}-{transaction.Date.Month}";
        }
    }
}
