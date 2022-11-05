using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using X.PagedList;

namespace ExamCreator.Areas.Admin.Service
{
    public abstract class BaseController<T> : Controller where T : class
    {
        private readonly IGenericService<T> _genericService;

        protected BaseController(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }


        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var datas = await _genericService.GetAllAsnyc().ToPagedListAsync(page, 10);
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult CreateBase()
        {
            return View();
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateBase(T t)
        {
            if (!ModelState.IsValid)
            {
                return View(t);
            }

            await _genericService.Insert(t);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public virtual async Task<IActionResult> EditBase(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = _genericService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        public virtual async Task<IActionResult> EditBase(T t)
        {
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            _genericService.Update(t);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> DeleteBase(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = _genericService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _genericService.Delete(data.Result);
            return View();
        }

        public virtual async Task<IActionResult> RemoveBase(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = _genericService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            _genericService.Remove(data.Result);
            return View();
        }
    }
}
