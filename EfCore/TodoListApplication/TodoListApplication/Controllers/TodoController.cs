using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoListApplication.Data;
using TodoListApplication.Models;

namespace TodoListApplication.Controllers
{
    public class TodoController : Controller
    {
        private DataContext _context;

        public TodoController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Todo> todos =
                _context.Todos //This is required to load child objects
                .ToList();

            return View(todos);
        }

        public IActionResult Add()
        {
            var todo = new Todo();
            return View(todo);
        }

        [HttpPost]
        public IActionResult Add(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
