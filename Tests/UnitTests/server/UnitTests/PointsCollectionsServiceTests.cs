using SquaresWebApi.Services;
using SquaresWebApi.Validators;
using Xunit;

namespace UnitTests
{
    public class PointsCollectionsServiceTests
    {
        [Fact]
        public void Test()
        {
            //Arrange 
            //var autoMapper = new Mapper();
            var pointsValidator = new PointsValidator();
            var pointsColectionsValidator = new PointsCollectionsValidator();
            var pointsCollectionService = new PointsCollectionsService(pointsValidator, pointsColectionsValidator);

            //Act

            //Assert
        }
    }
}
