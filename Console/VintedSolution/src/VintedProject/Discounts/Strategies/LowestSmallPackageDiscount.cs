using VintedProject.Models;

namespace VintedProject.Discounts.Strategies
{
    public class LowestSmallPackageDiscount : IDiscount
    {
        private List<ShippingInfo> _shippingInfos;

        public LowestSmallPackageDiscount(List<ShippingInfo> shippingInfos)
        {
            _shippingInfos = shippingInfos;
        }

        public bool Applies(ShippingTransaction transaction, Dictionary<string, List<ProcessedShipping>> processedShippings)
        {
            return transaction.PackageSize == Enums.PackageSize.S;
        }

        public void Process(ShippingTransaction transaction)
        {
            decimal lowestShippingPrice = _shippingInfos.Where(si => si.PackageSize == Enums.PackageSize.S)
                .Min(si => si.Price);

            var discount = transaction.Price.Value - lowestShippingPrice;

            transaction.Price = lowestShippingPrice;
            transaction.Discount = discount;
        }
    }
}
