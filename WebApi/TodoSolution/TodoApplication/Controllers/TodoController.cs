using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TodoApplication.Data;
using TodoApplication.Dtos;
using TodoApplication.Models;

namespace TodoApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public TodoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dataContext.Todos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _dataContext.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(CreateTodo createTodo)
        {
            var model = new Todo
            {
                Name = createTodo.Name
            };

            _dataContext.Todos.Add(model);
            _dataContext.SaveChanges();

            return Created("", model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateTodo todoUpdate)
        {
            if (ModelState.ErrorCount > 0)
            {
                return BadRequest(ModelState);
            }

            var todo = _dataContext.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Name = todoUpdate.Name;

            _dataContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _dataContext.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            _dataContext.Remove(todo);
            _dataContext.SaveChanges();

            return NoContent();
        }
    }
}
