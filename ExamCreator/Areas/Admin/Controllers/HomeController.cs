using Business.Abstract;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Service;
using Microsoft.AspNetCore.Mvc;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class HomeController : BaseController<Grade>
    {
        public HomeController(IGenericService<Grade> genericService) : base(genericService)
        {
        }

        [HttpGet]
        public override Task<IActionResult> Index(int page = 1)
        {
            return base.Index(page);
        }

        [HttpGet]
        public override IActionResult CreateBase()
        {
            return base.CreateBase();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override Task<IActionResult> CreateBase(Grade t)
        {
            return base.CreateBase(t);
        }

        [HttpGet]
        public override Task<IActionResult> EditBase(Guid id)
        {
            return base.EditBase(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override Task<IActionResult> EditBase(Grade t)
        {
            return base.EditBase(t);
        }

        public override Task<IActionResult> DeleteBase(Guid id)
        {
            return base.DeleteBase(id);
        }

        public override Task<IActionResult> RemoveBase(Guid id)
        {
            return base.RemoveBase(id);
        }
    }
}
