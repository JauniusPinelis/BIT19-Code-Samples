using VintedProject.Discounts.Strategies;
using VintedProject.Models;

namespace VintedProject.Discounts
{
    public class DiscountFactory
    {
        public IDiscount Build(ShippingTransaction transaction, List<ShippingInfo> shippingInfos)
        {
            // Logic which will decide which discount to pick
            if (transaction.PackageSize == Enums.PackageSize.S)
            {
                return new LowestSmallPackageDiscount(shippingInfos);
            }

            return null;
        }
    }
}
