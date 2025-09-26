using Microsoft.AspNetCore.Mvc;

namespace EFTest.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
