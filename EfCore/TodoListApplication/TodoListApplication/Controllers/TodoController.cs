using Microsoft.AspNetCore.Mvc;
using TodoListApplication.Dtos;
using TodoListApplication.Models;
using TodoListApplication.Repositories;

namespace TodoListApplication.Controllers
{
    public class TodoController : Controller
    {
        private TodoRepository _todoRepository;
        private CategoryRepository _categoryRepository;
        private TagRepository _tagRepository;

        public TodoController(TodoRepository todoRepository, CategoryRepository categoryRepository, TagRepository tagRepository)
        {
            _todoRepository = todoRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
        }

        public IActionResult Index()
        {
            return View(_todoRepository.GetAll());
        }

        public IActionResult Add()
        {
            var createTodo = new CreateTodo()
            {
                Todo = new Todo(),
                AllCategories = _categoryRepository.GetAll(),
                Tags = _tagRepository.GetAll()
            };
            return View(createTodo);
        }

        [HttpPost]
        public IActionResult Add(CreateTodo createTodo)
        {
            if (!ModelState.IsValid)
            {
                createTodo.AllCategories = _categoryRepository.GetAll();
                return View(createTodo);
            }

            _todoRepository.Create(createTodo.Todo, createTodo.SelectedTagIds);


            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _todoRepository.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var todo = _todoRepository.GetById(id);
            return View(todo);
        }

        [HttpPost]
        public IActionResult Update(Todo todo)
        {
            _todoRepository.Update(todo);
            return RedirectToAction("Index");
        }


    }
}
