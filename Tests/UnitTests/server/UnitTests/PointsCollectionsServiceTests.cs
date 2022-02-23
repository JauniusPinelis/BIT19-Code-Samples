using AutoMapper;
using Moq;
using SquaresWebApi.Dtos.MappingProfiles;
using SquaresWebApi.Models;
using SquaresWebApi.Repositories;
using SquaresWebApi.Services;
using SquaresWebApi.Validators;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class PointsCollectionsServiceTests
    {
        [Fact]
        public async Task DeleteAsync_GivenValidPointsCollectionId_ServiceCompletesSuccessfully()
        {
            // Arrange
            var pointsValidator = new PointsValidator();
            var pointsColectionsValidator = new PointsCollectionsValidator();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            IMapper mapper = new Mapper(config);

            var mockPointsRepository = new Mock<IPointsRepository>();

            var mockPointsCollectionsRepository = new Mock<IPointsCollectionsRepository>();

            mockPointsCollectionsRepository.Setup(p => p.GetByIdIncludedAsync(It.IsAny<int>()))
               .ReturnsAsync(new PointsCollection());


            var pointsCollectionService = new PointsCollectionsService(mockPointsCollectionsRepository.Object, mockPointsRepository.Object, mapper, pointsColectionsValidator, pointsValidator);

            // Act and Assert
            await pointsCollectionService.DeleteAsync(5);
        }
    }
}
