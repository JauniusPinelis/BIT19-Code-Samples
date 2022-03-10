using VintedProject.Enums;

namespace VintedProject.Models
{
    public class ProcessedShipping
    {
        public decimal Discount { get; set; }

        public ShippingProvider Provider { get; set; }

        public PackageSize Size { get; set; }
    }
}
