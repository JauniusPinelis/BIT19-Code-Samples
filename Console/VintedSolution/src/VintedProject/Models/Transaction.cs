using VintedProject.Enums;

namespace VintedProject.Models
{
    public class Transaction
    {
        public DateOnly Date { get; set; }

        public PackageSize PackageSize { get; set; }

        public ShippingProvider Provider { get; set; }

        public decimal? Price { get; set; }
        public decimal Discount { get; set; }

        public bool IsValid { get; set; } = true;

        public string ParametersText { get; set; }

        public override string ToString()
        {
            var discountText = Discount != 0 ? Discount.ToString("0.00") : "-";

            return IsValid
                ? $"{Date.ToString("yyyy-MM-dd")} {PackageSize} {Provider} {Price.Value.ToString("0.00")} {discountText}"
                : ParametersText + " Ignored";
        }
    }
}
