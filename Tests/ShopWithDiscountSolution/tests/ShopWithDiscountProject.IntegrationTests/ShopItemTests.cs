using FluentAssertions;
using ShopWithDiscountProject.Dtos.ShopItems;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ShopWithDiscountProject.IntegrationTests
{
    public class ShopItemTests
    {
        private HttpClient _client;
        private CustomWebApplicationFactory<Startup> _factory;

        public ShopItemTests()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Test()
        {
            var createShopItem = new CreateShopItem()
            {
                Name = "Candy",
                Price = 2
            };

            await _client.PostAsJsonAsync("/shopitem", createShopItem);

            var result = await _client.GetAsync("/shopitem");

            result.EnsureSuccessStatusCode();

            var shopItems = await result.Content.ReadAsAsync<List<ShopItemDto>>();

            shopItems.Count.Should().Be(1);
            shopItems[0].Name.Should().Be("Candy");
        }
    }
}
