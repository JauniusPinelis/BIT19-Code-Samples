using Microsoft.AspNetCore.Mvc;
using TodoListApplication.Dtos;
using TodoListApplication.Models;
using TodoListApplication.Repositories;

namespace TodoListApplication.Controllers
{
    public class CategoryController : Controller
    {

        private CategoryRepository _categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Add()
        {
            var createCategory = new CreateCategory();
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateCategory createCategory)
        {
            var category = new Category()
            {
                Name = createCategory.Name,
            };

            _categoryRepository.Create(category);


            return RedirectToAction("Add");
        }
    }
}
