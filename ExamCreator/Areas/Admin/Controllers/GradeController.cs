using Business.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var datas = await _gradeService.GetAllAsnyc().ToListAsync();
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(Grade t)
        {
            if (!ModelState.IsValid)
            {
                return View(t);
            }

            await _gradeService.Insert(t);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = _gradeService.GetByIdAsnyc(id);
            if (data.Result == null)
            {
                return NotFound();
            }
            return View(data.Result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Edit(Grade t)
        {
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            await _gradeService.Update(t, t.Id);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = _gradeService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _gradeService.Delete(data.Result);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Remove(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = _gradeService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            _gradeService.Remove(data.Result);
            return RedirectToAction(nameof(Index));
        }
    }
}
