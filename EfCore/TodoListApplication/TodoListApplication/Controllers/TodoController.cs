using Microsoft.AspNetCore.Mvc;

namespace TodoListApplication.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
