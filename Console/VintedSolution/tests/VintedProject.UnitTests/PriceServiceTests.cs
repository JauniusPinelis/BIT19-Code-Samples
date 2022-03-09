using FluentAssertions;
using System.Collections.Generic;
using VintedProject.Enums;
using VintedProject.Models;
using VintedProject.Services;
using Xunit;

namespace VintedProject.UnitTests
{
    public class PriceServiceTests
    {
        [Fact]
        public void Test1()
        {
            var shippingInfos = new List<ShippingInfo>
            {
                new ShippingInfo()
                {
                    Provider = ShippingProvider.LP,
                    PackageSize = PackageSize.S,
                    Price = 1.5M
                }
            };

            var transaction = new ShippingTransaction
            {
                Date = System.DateOnly.MaxValue,
                PackageSize = PackageSize.S,
                Provider = ShippingProvider.LP
            };

            var priceService = new PriceService();

            var calculatedTransaction = priceService.CalculatePrice(transaction, shippingInfos);

            calculatedTransaction.Should().Be(shippingInfos[0].Price);
        }
    }
}