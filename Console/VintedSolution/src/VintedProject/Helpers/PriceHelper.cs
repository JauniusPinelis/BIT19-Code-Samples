using VintedProject.Models;

namespace VintedProject.Helpers
{
    public static class PriceHelper
    {
        public static decimal CalculatePrice(Transaction transaction, List<ShippingInfo> shippingInfos)
        {
            var price = shippingInfos.FirstOrDefault(s => s.PackageSize == transaction.PackageSize
                && s.Provider == transaction.Provider);

            return price.Price;
        }
    }
}
