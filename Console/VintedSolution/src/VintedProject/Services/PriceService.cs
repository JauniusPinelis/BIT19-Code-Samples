using VintedProject.Models;

namespace VintedProject.Services
{
    public class PriceService
    {

        public PriceService()
        {
        }

        public decimal CalculatePrice(ShippingTransaction transaction, List<ShippingInfo> shippingInfos)
        {
            var price = shippingInfos.FirstOrDefault(s => s.PackageSize == transaction.PackageSize
                && s.Provider == transaction.Provider);

            return price.Price;
        }
    }
}
