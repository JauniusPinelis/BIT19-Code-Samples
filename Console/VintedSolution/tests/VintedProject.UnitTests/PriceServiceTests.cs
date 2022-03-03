using FluentAssertions;
using Moq;
using System.Collections.Generic;
using VintedProject.Interfaces;
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
                    Provider = "LP",
                    PackageSize = "S",
                    Price = 1.5M
                }
            };

            var transaction = new ShippingTransaction
            {
                Date = System.DateOnly.MaxValue,
                PackageSize = "S",
                Provider = "LP"
            };

            var fileServiceMock = new Mock<IFileService>();
            fileServiceMock.Setup(x => x.LoadShippingInfos())
                .Returns(shippingInfos);

            var priceService = new PriceService(fileServiceMock.Object);

            var calculatedTransaction = priceService.CalculatePrice(transaction);

            calculatedTransaction.Should().Be(shippingInfos[0].Price);
        }
    }
}