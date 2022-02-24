using Microsoft.AspNetCore.Mvc;
using ShopWithDiscountProject.Dtos.ShopItems;
using ShopWithDiscountProject.Services;
using System;
using System.Threading.Tasks;

namespace ShopWithDiscountProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopItemController : ControllerBase
    {
        private readonly ShopItemService _shopItemService;

        public ShopItemController(ShopItemService shopItemService)
        {
            _shopItemService = shopItemService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateShopItem createShopItem)
        {
            var createdDto = await _shopItemService.CreateAsync(createShopItem);
            return Ok(createdDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _shopItemService.GetAllAsync());
        }

        [HttpPost("/buy")]
        public async Task<IActionResult> Buy(BuyInformation buyInformation)
        {
            try
            {
                return Ok(await _shopItemService.CalculatePriceAsync(buyInformation));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
