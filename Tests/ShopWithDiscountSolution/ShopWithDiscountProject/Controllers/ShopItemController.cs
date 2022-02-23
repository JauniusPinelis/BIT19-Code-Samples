using Microsoft.AspNetCore.Mvc;

namespace ShopWithDiscountProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopItemController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpPost("/buy")]
        public IActionResult GetAll(BuyInformation buyInformation)
        {
            return Ok();
        }
    }
}
