using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using VintedProject.Interfaces;
using VintedProject.Services;
using Xunit;

namespace VintedProject.UnitTests
{
    public class FileServiceTests
    {

        [Fact]
        public async Task LoadShippingInfosAsync_GivenCorrectData_ParsesDataSucessfully()
        {
            // Arrange
            var importTextServiceMock = new Mock<ITextImportService>();
            importTextServiceMock.Setup(its => its.ReadShippingInfoText())
                .ReturnsAsync(new string[]
                {
                    "LP S 1.50",
                    "LP M 4.9",
                    "LP L 4.9"
                });

            var fileService = new FileService(importTextServiceMock.Object);

            //Act
            var shippingInfos = await fileService.LoadShippingInfosAsync();

            //Assert
            shippingInfos.Count.Should().Be(3);
        }

        [Fact]
        public async Task LoadTransactionsAsync_GivenCorrectData_ParsesDataSucessfully()
        {
            // Arrange
            var importTextServiceMock = new Mock<ITextImportService>();
            importTextServiceMock.Setup(its => its.ReadTransactionsText())
                .ReturnsAsync(new string[]
                {
                    "2015-02-01 S MR",
                    "2015-02-01 L MR",
                });

            var fileService = new FileService(importTextServiceMock.Object);

            //Act
            var transactions = await fileService.LoadTransactionsAsync();

            //Assert
            transactions.Count.Should().Be(2);
            transactions[0].Date.Should().Be(new System.DateOnly(2015, 02, 01));
            transactions[0].PackageSize.Should().Be("S");
            transactions[0].Provider.Should().Be("MR");
            transactions.ForEach(t => t.IsValid.Should().BeTrue());
        }

        [Fact]
        public async Task LoadTransactionsAsync_GivenInrorrectData_ParsesDataSucessfully()
        {
            // Arrange
            var importTextServiceMock = new Mock<ITextImportService>();
            importTextServiceMock.Setup(its => its.ReadTransactionsText())
                .ReturnsAsync(new string[]
                {
                    "2015-02-29 CUSPS",
                    "2015-02-02 CUSPS",
                    "2015-02-29 L MR",
                });

            var fileService = new FileService(importTextServiceMock.Object);

            //Act
            var transactions = await fileService.LoadTransactionsAsync();

            //Assert
            transactions.ForEach(t => t.IsValid.Should().BeFalse());
        }
    }
}
