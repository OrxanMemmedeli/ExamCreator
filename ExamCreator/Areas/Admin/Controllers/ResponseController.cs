using Microsoft.AspNetCore.Mvc;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class ResponseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
