using Microsoft.AspNetCore.Mvc;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class QuestionTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
