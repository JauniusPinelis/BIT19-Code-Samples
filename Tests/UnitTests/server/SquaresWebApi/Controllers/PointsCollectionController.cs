using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SquaresWebApi.Dtos.PointsCollectionDtos;
using SquaresWebApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SquaresWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsCollectionController : ControllerBase
    {
        private readonly PointsCollectionsService _pointsCollectionService;

        public PointsCollectionController(PointsCollectionsService pointsCollectionService)
        {
            _pointsCollectionService = pointsCollectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<PointsCollectionGetAllDto> collectionsDto = await _pointsCollectionService.GetAllAsync();

                return Ok(collectionsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                PointsCollectionGetDto collectionDto = await _pointsCollectionService.GetByIdAsync(id);
                return Ok(collectionDto);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(PointsCollectionCreateDto collectionDto)
        {
            try
            {
                await _pointsCollectionService.CreateAsync(collectionDto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _pointsCollectionService.DeleteAsync(id);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
