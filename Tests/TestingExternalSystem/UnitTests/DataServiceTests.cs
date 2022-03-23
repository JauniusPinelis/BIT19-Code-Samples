using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using TestingExternalSystem.Clients;
using TestingExternalSystem.Services;
using Xunit;

namespace UnitTests
{
    public class DataServiceTests
    {
        [Fact]
        public async Task Test1()
        {
            Mock<IExternalSystemClient> externalSystemClientMock = new Mock<IExternalSystemClient>();

            externalSystemClientMock.Setup(esc => esc.GetTodosAsync())
                .ReturnsAsync(new System.Collections.Generic.List<TestingExternalSystem.Models.Todo>()
                {
                    new TestingExternalSystem.Models.Todo()
                    {
                        Title = "Ye"
                    }
                });

            //Arrange
            DataService dataService = new DataService(externalSystemClientMock.Object);

            //Act
            var number = await dataService.CalculateShortWordsFromApi();

            //assert
            number.Should().Be(1);
        }
    }
}