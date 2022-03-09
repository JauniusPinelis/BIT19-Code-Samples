using VintedProject.Enums;

namespace VintedProject.Models
{
    public class ShippingInfo
    {
        public ShippingProvider Provider { get; set; }

        public PackageSize PackageSize { get; set; }

        public decimal Price { get; set; }
    }
}
