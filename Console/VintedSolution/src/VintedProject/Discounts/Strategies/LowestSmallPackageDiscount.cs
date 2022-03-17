using VintedProject.Models;

namespace VintedProject.Discounts.Strategies
{
    public class LowestSmallPackageDiscount : DiscountBase, IDiscount
    {
        private List<ShippingInfo> _shippingInfos;

        public LowestSmallPackageDiscount(List<ShippingInfo> shippingInfos, Dictionary<string, List<ProcessedShipping>> processedShippings)
            : base(processedShippings)
        {
            _shippingInfos = shippingInfos;
        }

        public bool Applies(Transaction transaction, Dictionary<string, List<ProcessedShipping>> processedShippings)
        {
            return transaction.PackageSize == Enums.PackageSize.S;
        }

        public void Process(Transaction transaction)
        {
            decimal lowestShippingPrice = _shippingInfos.Where(si => si.PackageSize == Enums.PackageSize.S)
                .Min(si => si.Price);

            var discount = transaction.Price.Value - lowestShippingPrice;

            transaction.Price = lowestShippingPrice;
            transaction.Discount = discount;

            LimitDiscount(transaction);
        }
    }
}
