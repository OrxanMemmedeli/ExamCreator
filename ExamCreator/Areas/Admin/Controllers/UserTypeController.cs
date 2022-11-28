using Microsoft.AspNetCore.Mvc;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class UserTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
