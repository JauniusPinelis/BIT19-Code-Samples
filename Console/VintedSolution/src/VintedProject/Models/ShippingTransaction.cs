namespace VintedProject.Models
{
    public class ShippingTransaction
    {
        public DateOnly Date { get; set; }

        public string PackageSize { get; set; }

        public string Provider { get; set; }

        public decimal? Price { get; set; }
    }
}
