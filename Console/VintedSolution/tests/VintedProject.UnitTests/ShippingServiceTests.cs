using FluentAssertions;
using System.IO;
using System.Threading.Tasks;
using VintedProject.Discounts;
using VintedProject.Services;
using VintedProject.UnitTests.Services;
using Xunit;

namespace VintedProject.UnitTests
{
    public class ShippingServiceTests
    {
        [Fact]
        public async Task ProcessPricesAsync_PrintingResultsToFile_ShouldBeEqualToExample()
        {
            var textImportService = new TextImportService();
            var fileService = new ImportService(textImportService);

            var fileOutputService = new FileOutputService();

            var discountFactory = new DiscountFactory();

            var shippingService = new ShippingService(fileService, fileOutputService, discountFactory);
            await shippingService.ProcessPricesAsync();

            var processedTransactions = await File.ReadAllLinesAsync("Data/Output.txt");
            var sampleTransactions = await File.ReadAllLinesAsync("Data/Sample.txt");

            for (int i = 0; i < processedTransactions.Length; i++)
            {
                processedTransactions[i].Should().Be(sampleTransactions[i]);
            }
        }
    }
}
