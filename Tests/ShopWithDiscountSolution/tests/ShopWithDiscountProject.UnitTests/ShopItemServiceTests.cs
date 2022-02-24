using AutoMapper;
using Moq;
using ShopWithDiscountProject.Dtos;
using ShopWithDiscountProject.MappingProfiles;
using ShopWithDiscountProject.Repositories;
using ShopWithDiscountProject.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ShopWithDiscountProject.UnitTests
{
    public class ShopItemServiceTests
    {
        private readonly ShopItemService _shopItemService;
        private readonly Mock<IShopItemRepository> _shopItemRepositoryMock;

        public ShopItemServiceTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            _shopItemRepositoryMock = new Mock<IShopItemRepository>();

            _shopItemService = new ShopItemService(mapper, _shopItemRepositoryMock.Object);
        }

        [Fact]
        public async Task CalculatePriceAsync_GivenValidItems_CalculatePriceCorrectly()
        {
            //arrange
            var exampleShopItem = new Models.ShopItem()
            {
                Name = "Candy",
                Price = 10M
            };

            _shopItemRepositoryMock.Setup(r => r.GetShopByNameAsync("Candy"))
                .ReturnsAsync(exampleShopItem);

            var buyInformation = new BuyInformation()
            {
                BuyDtos = new List<BuyDto>()
                {
                    new BuyDto()
                    {
                        ShopItemName = "Candy",
                        Quantity = 10
                    }
                }
            };

            //act
            var price = await _shopItemService.CalculatePriceAsync(buyInformation);

            //asert
            Assert.Equal(100M, price);
        }

        [Fact]
        public async Task CalculatePriceAsync_GivenIncorrectName_ThrowsArgumentException()
        {
            //arrange
            var exampleShopItem = new Models.ShopItem()
            {
                Name = "Candy",
                Price = 10M
            };

            var buyInformation = new BuyInformation()
            {
                BuyDtos = new List<BuyDto>()
                {
                    new BuyDto()
                    {
                        ShopItemName = "Candy",
                        Quantity = 10
                    }
                }
            };

            //act
            await Assert.ThrowsAsync<ArgumentException>(() => _shopItemService.CalculatePriceAsync(buyInformation));
        }
    }
}