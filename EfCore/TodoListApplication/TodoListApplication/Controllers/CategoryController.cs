using Microsoft.AspNetCore.Mvc;
using TodoListApplication.Data;
using TodoListApplication.Dtos;
using TodoListApplication.Models;

namespace TodoListApplication.Controllers
{
    public class CategoryController : Controller
    {

        private DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
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

            category.Created = System.DateTime.Now;
            category.LastModified = System.DateTime.Now;

            _context.Categories.Add(category);

            _context.SaveChanges();

            return RedirectToAction("Add");
        }
    }
}
