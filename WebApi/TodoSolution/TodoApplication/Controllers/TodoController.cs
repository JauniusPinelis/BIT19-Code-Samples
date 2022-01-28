using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoApplication.Data;
using TodoApplication.Dtos;
using TodoApplication.Services;

namespace TodoApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private TodoService _todoService;

        public TodoController(DataContext dataContext, TodoService todoService)
        {
            _dataContext = dataContext;
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var asyncResults = await _dataContext.Todos
                .Where(t => t.Name == "First")
                .Where(t => t.Name == "First")
                .Where(t => t.Name == "First")
                .ToListAsync();


            return Ok(asyncResults);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _todoService.GetByIdAsync(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodo createTodo)
        {
            try
            {
                var createdId = await _todoService.CreateAsync(createTodo);
                return Created("", createdId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTodo todoUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _todoService.UpdateAsync(id, todoUpdate);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _todoService.RemoveAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
