using Microsoft.AspNetCore.Mvc;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
