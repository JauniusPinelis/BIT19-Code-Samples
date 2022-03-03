using VintedProject.Interfaces;
using VintedProject.Models;

namespace VintedProject.Services
{
    public class PriceService
    {
        private List<ShippingInfo> _shippingInfos;
        private IFileService _fileService;

        public PriceService(IFileService fileService)
        {
            _fileService = fileService;

            _shippingInfos = _fileService.LoadShippingInfos();
        }


        public decimal CalculatePrice(ShippingTransaction transaction)
        {
            var price = _shippingInfos.FirstOrDefault(s => s.PackageSize == transaction.PackageSize
                && s.Provider == transaction.Provider);

            return price.Price;
        }
    }
}
