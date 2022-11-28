using Microsoft.AspNetCore.Mvc;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class AcademicYearController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
