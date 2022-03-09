using VintedProject.Enums;

namespace VintedProject.Models
{
    public class ShippingTransaction
    {
        public DateOnly Date { get; set; }

        public PackageSize PackageSize { get; set; }

        public ShippingProvider Provider { get; set; }

        public decimal? Price { get; set; }

        public bool IsValid { get; set; } = true;

        public string ParametersText { get; set; }

        public override string ToString()
        {
            return IsValid
                ? $"{Date.ToString("yyyy-MM-dd")} {PackageSize} {Provider} {Price}"
                : ParametersText;
        }
    }
}
