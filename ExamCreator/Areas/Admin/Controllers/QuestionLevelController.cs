using Microsoft.AspNetCore.Mvc;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class QuestionLevelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
