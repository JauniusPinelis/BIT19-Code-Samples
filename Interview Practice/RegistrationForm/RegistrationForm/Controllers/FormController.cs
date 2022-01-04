using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationForm.Data;
using RegistrationForm.Models;

namespace RegistrationForm.Controllers
{
    public class FormController : Controller
    {
        private DataContext _dataContext;

        public FormController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var form = _dataContext.Forms.Include(f => f.Questions).ThenInclude(q => q.PossibleAnswers).FirstOrDefault();
            return View(form);
        }

        public IActionResult Submit(Form form)
        {
            _dataContext.Update(form); // This update is faulty
            _dataContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
