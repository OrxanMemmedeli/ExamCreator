using Microsoft.AspNetCore.Mvc;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class SectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
