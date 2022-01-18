using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApplication.Data;
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
        public List<Todo> GetAll()
        {
            return _dataContext.Todos.ToList();
        }

        [HttpGet("{id}")]
        public Todo GetById(int id)
        {
            return _dataContext.Todos.Find(id);
        }

        [HttpPost]
        public void Create(Todo todo)
        {
            _dataContext.Todos.Add(todo);
            _dataContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Update(int id, Todo todoUpdate)
        {
            var todo = _dataContext.Todos.Find(id);

            todo.Name = todoUpdate.Name;

            _dataContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var todo = _dataContext.Todos.Find(id);
            _dataContext.Remove(todo);
            _dataContext.SaveChanges();
        }
    }

    
}
