using Microsoft.AspNetCore.Mvc;
using SquaresWebApi.Repositories;
using System.Threading.Tasks;

namespace SquaresWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly IPointsRepository _pointsRepository;

        public PointsController(IPointsRepository pointsRepository)
        {
            _pointsRepository = pointsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _pointsRepository.GetAllAsync());
        }
    }
}
