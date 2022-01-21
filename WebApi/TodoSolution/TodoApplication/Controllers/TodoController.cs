using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
        public IActionResult GetAll()
        {
            return Ok(_dataContext.Todos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_todoService.GetById(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Create(CreateTodo createTodo)
        {
            try
            {
                var createdId = _todoService.Create(createTodo);
                return Created("", createdId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateTodo todoUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _todoService.Update(id, todoUpdate);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _todoService.Remove(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
